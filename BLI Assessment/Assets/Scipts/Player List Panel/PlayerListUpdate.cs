using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListUpdate : MonoBehaviour
{
    [SerializeField] private InstansiateNewRow _newRow;
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

        _newRow.CreateNewRow(newIndex, newIndex);
    }
}
