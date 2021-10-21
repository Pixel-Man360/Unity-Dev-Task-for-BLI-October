using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerListInitialize : MonoBehaviour
{
    [SerializeField] private InstansiateNewRow _newRow;
    void Start()
    {
        int dataSize = PlayerDatabase.instance.GetDatabaseSize();

        _newRow.CreateNewRow(1, dataSize);
    }

    
}
