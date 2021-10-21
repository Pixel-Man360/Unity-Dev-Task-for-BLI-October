using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InstansiateNewRow 
{
    public GameObject container;
    public GameObject template;

    public void CreateNewRow(int startVal, int dataSize)
    {
        for(int i = startVal ; i <= dataSize; i++)
        {
            GameObject newPlayer = UnityEngine.MonoBehaviour.Instantiate(template, container.transform);
            string[] data = PlayerDatabase.instance.PullFromDatabase(i);
            
            newPlayer.transform.GetChild(0).GetComponent<Text>().text = data[0];
            newPlayer.transform.GetChild(1).GetComponent<Text>().text = data[1];
            newPlayer.transform.GetChild(2).GetComponent<Text>().text = data[2];
        }
    }
}
