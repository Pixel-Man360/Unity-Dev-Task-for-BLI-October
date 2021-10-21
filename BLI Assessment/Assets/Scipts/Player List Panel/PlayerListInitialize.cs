using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerListInitialize : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _template;
    void Start()
    {
        int dataSize = PlayerDatabase.instance.GetDatabaseSize();

        for(int index = 1; index <= dataSize; index++)
        {
            GameObject newPlayer = Instantiate(_template, _container.transform);
            string[] playerData = PlayerDatabase.instance.PullFromDatabase(index);

            newPlayer.transform.GetChild(0).GetComponent<Text>().text = playerData[0];
            newPlayer.transform.GetChild(1).GetComponent<Text>().text = playerData[1];
            newPlayer.transform.GetChild(2).GetComponent<Text>().text = playerData[2];

        }  
    }

    
}
