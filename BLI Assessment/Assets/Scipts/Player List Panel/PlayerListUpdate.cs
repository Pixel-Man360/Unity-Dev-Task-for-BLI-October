using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListUpdate : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    void OnEnable() 
    {
       UserInputEntryPanel.OnEntryPanelAddButtonPressed += UpdateList;
    }

    void OnDisable() 
    {
        UserInputEntryPanel.OnEntryPanelAddButtonPressed -= UpdateList;
    }

    void UpdateList()
    {
        int newIndex = PlayerDatabase.instance.GetDatabaseSize();

        GameObject newPlayer = Instantiate(_template, _container.transform);
        string[] playerData = PlayerDatabase.instance.PullFromDatabase(newIndex);

        newPlayer.transform.GetChild(0).GetComponent<Text>().text = playerData[0];
        newPlayer.transform.GetChild(1).GetComponent<Text>().text = playerData[1];
        newPlayer.transform.GetChild(2).GetComponent<Text>().text = playerData[2];
    }
}
