using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUpdateWhileSearch : MonoBehaviour
{
    
    [SerializeField] private Text _searchText;
    [SerializeField] private Button _searchButton;
    [SerializeField] private Button _resetButton;
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _template;
   

    void Awake()
    {
        _searchButton?.onClick.AddListener(UpdateListOnSearch);
        _resetButton?.onClick.AddListener(ResetList);
    }

    void UpdateListOnSearch()
    {


        foreach (Transform child in _container.transform) 
        {     
            GameObject.Destroy(child.gameObject); 
        }

        string[,] data = PlayerDatabase.instance.PullFromDatabase(_searchText.text);

        int index = data.GetLength(0);

        for(int i = 0 ; i < index; i++)
        {
            GameObject newPlayer = Instantiate(_template, _container.transform);
            newPlayer.transform.GetChild(0).GetComponent<Text>().text = data[i,0];
            newPlayer.transform.GetChild(1).GetComponent<Text>().text = data[i,1];
            newPlayer.transform.GetChild(2).GetComponent<Text>().text = data[i,2];
        }
    
        
    }

    void ResetList()
    {
        foreach (Transform child in _container.transform) 
        {     
            GameObject.Destroy(child.gameObject); 
        }
        
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
