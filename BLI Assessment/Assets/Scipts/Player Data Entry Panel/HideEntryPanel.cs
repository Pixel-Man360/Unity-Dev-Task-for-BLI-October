using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideEntryPanel : MonoBehaviour
{
    [SerializeField] private GameObject _dataEntryPanel;
    
    void OnEnable()
    {
        UserInputEntryPanel.OnEntryPanelAddButtonPressed += Hide;
        UserInputEntryPanel.OnExitButtonPressed += Hide;
        
    }

    void OnDisable()
    {
        UserInputEntryPanel.OnEntryPanelAddButtonPressed -= Hide;
        UserInputEntryPanel.OnExitButtonPressed -= Hide;
    }

    void Hide()
    {
        _dataEntryPanel.SetActive(false);
    }
}
