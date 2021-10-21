using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputEntryPanel : MonoBehaviour
{
    [SerializeField] private Text _nameInputText;
    [SerializeField] private Text _ageInputText;
    [SerializeField] private Text _typeInputText;
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _exitButton;

    private WarningMessage _warning;
    
    public static event Action OnEntryPanelAddButtonPressed;
    public static event Action OnExitButtonPressed;

    void Awake() 
    {
        _warning = GetComponent<WarningMessage>();
    }
    void Start()
    {
        _addButton?.onClick.AddListener(AddPlayer);
        _exitButton?.onClick.AddListener(ExitFromPanel);
    }

    void AddPlayer()
    {
        PlayerDatabase.instance.AddToDatabase(_nameInputText.text, _ageInputText.text, _typeInputText.text);

        if(_nameInputText.text == "" || _ageInputText.text == "")
        {
           _warning.ShowWarning();
        }
        else
        {
            OnEntryPanelAddButtonPressed?.Invoke();
        }

    }

    void ExitFromPanel()
    {
        OnExitButtonPressed?.Invoke();
    }
}
