using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;


public class PlayerDatabase : MonoBehaviour
{
    private string _databaseName = "URI=file:PlayerDatabase.db";
 

    public static PlayerDatabase instance;
    void Awake()
    {
        if(instance == null)
         instance = this;
    }

    void Start()
    {
        UseDatabase("CREATE TABLE IF NOT EXISTS PlayerData (name VARCHAR(50), age VARCHAR(10), type VARCHAR(15));");
    }

    void UseDatabase(string comm)
    {
        using(var connection = new SqliteConnection(_databaseName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = comm;
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
    
    string[] ReadDatabase(string comm)
    {
        string[] data = new string[3];
        using(var connection = new SqliteConnection(_databaseName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = comm;
                using(IDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        data[0] = Convert.ToString(reader["name"]);
                        data[1] = Convert.ToString(reader["age"]);
                        data[2] = Convert.ToString(reader["type"]);
                    }

                    reader.Close();
                    
                }
            }

            connection.Close();
        }

        return data;
    }

    string[,] ReadDatabaseSearch(string comm)
    {
        string[,] data = new string[10000,3];

        using(var connection = new SqliteConnection(_databaseName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = comm;
                using(IDataReader reader = command.ExecuteReader())
                {
                    int index = 0;

                    while(reader.Read())
                    {
                        data[index,0] = Convert.ToString(reader["name"]);
                        data[index,1] = Convert.ToString(reader["age"]);
                        data[index,2] = Convert.ToString(reader["type"]);
                        index++;
                    }

                    reader.Close();
                    
                }
            }

            connection.Close();
        }

        return data;
    }
   
    public void AddToDatabase(string name, string age, string type) 
    {
       UseDatabase("INSERT INTO PlayerData(name, age, type) VALUES ('" + name + "','" + age + "', '" + type + "');");
    }


    public string[] PullFromDatabase(int index)
    {
       return ReadDatabase("SELECT * FROM PlayerData WHERE rowid = " + index + ";");
    }

    public string[,] PullFromDatabase(string name)
    {
       string nameToSearch = "'" + name + "%" + "'";
       return ReadDatabaseSearch("SELECT * FROM PlayerData WHERE name LIKE " + nameToSearch + ";");

    }

    public int GetDatabaseSize()
    {
        int size = 0;
        using(var connection = new SqliteConnection(_databaseName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) from PlayerData";
                
                size = Convert.ToInt32(command.ExecuteScalar());
            }

            connection.Close();
        }

        return size;
        
    }


    

   
}
