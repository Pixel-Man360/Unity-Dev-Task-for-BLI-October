using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpdateWhileSearch : MonoBehaviour
{
    [SerializeField] private InputField _searchInputField;
    [SerializeField] private Text _searchText;
    [SerializeField] private Button _searchButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private InstansiateNewRow _newRow;
    private bool _canUpdate;

    void Awake()
    {
        _canUpdate = false;
        _searchButton?.onClick.AddListener(UpdateListOnSearch);
        _resetButton?.onClick.AddListener(ResetList);
        _searchInputField.onValueChanged.AddListener(delegate {DynamicSearch();});
    }

    void DynamicSearch()
    {
        if(_searchText.text == "" && _canUpdate)
        {
            _canUpdate = false;
            ResetList();
        }

        else if(_searchText.text != "")
        {
            _canUpdate = true;
            UpdateListOnSearch();
        }
    }

    void UpdateListOnSearch()
    {

        foreach (Transform child in _newRow.container.transform) 
        {     
            GameObject.Destroy(child.gameObject); 
        }

        List<string[]> data = PlayerDatabase.instance.PullFromDatabase(_searchText.text);

        int index = data.Count;
        Debug.Log(index);

        for(int i = 0 ; i < index; i++)
        {
            GameObject newPlayer = Instantiate(_newRow.template, _newRow.container.transform);
            string[] val = data[i];
            newPlayer.transform.GetChild(0).GetComponent<Text>().text = val[0];
            newPlayer.transform.GetChild(1).GetComponent<Text>().text = val[1];
            newPlayer.transform.GetChild(2).GetComponent<Text>().text = val[2];
        }
    
    }

    void ResetList()
    {
        foreach (Transform child in _newRow.container.transform) 
        {     
             GameObject.Destroy(child.gameObject); 
        }

        int dataSize = PlayerDatabase.instance.GetDatabaseSize();
        _newRow.CreateNewRow(1, dataSize);
        
    }
}
