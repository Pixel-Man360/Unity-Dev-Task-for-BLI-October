using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEntryPanel : MonoBehaviour
{
    [SerializeField] private GameObject _dataEntryPanel;
    
    void OnEnable()
    {
        UserInputListPanel.OnPlayerListAddButtonClicked += Show;
        
    }

    void OnDisable()
    {
        UserInputListPanel.OnPlayerListAddButtonClicked -= Show;
    }

    void Show()
    {
        _dataEntryPanel.SetActive(true);
    }
}
