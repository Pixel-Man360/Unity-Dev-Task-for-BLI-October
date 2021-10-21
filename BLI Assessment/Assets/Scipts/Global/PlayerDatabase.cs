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
    
    public string[] PullFromDatabase(int index)
    {
        string[] data = new string[3];
        using(var connection = new SqliteConnection(_databaseName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM PlayerData WHERE rowid = " + index + ";";
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

   
   
    public void AddToDatabase(string name, string age, string type) 
    {
       UseDatabase("INSERT INTO PlayerData(name, age, type) VALUES ('" + name + "','" + age + "', '" + type + "');");
    }

    public List<string[]> PullFromDatabase(string name)
    {
        string nameToSearch = "'" + name + "%" + "'";
        string[] val = new string[3];
        List<string[]> data = new List<string[]>();

        using(var connection = new SqliteConnection(_databaseName))
        {
            connection.Open();

            using(var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM PlayerData WHERE name LIKE " + nameToSearch + ";";
                using(IDataReader reader = command.ExecuteReader())
                {
                    int index = 0;

                    while(reader.Read())
                    {
                        val[0] = Convert.ToString(reader["name"]);
                        val[1] = Convert.ToString(reader["age"]);
                        val[2] = Convert.ToString(reader["type"]);
                        data.Add(val);
                        index++;
                    }

                    reader.Close();
                    
                }
            }

            connection.Close();
        }

        return data;
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
