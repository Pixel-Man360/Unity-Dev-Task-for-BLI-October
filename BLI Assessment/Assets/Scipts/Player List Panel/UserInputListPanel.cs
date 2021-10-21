using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputListPanel : MonoBehaviour
{
    [SerializeField] private Button _addPlayerButton;

    public static event Action OnPlayerListAddButtonClicked;
    void Start()
    {
        _addPlayerButton?.onClick.AddListener(AddToList);
    }

    void AddToList()
    {
        OnPlayerListAddButtonClicked?.Invoke();
    }

    
}
