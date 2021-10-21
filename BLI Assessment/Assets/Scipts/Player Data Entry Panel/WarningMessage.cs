using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMessage : MonoBehaviour
{
    [SerializeField] private GameObject _warningText;
 
    
    public void ShowWarning()
    {
        StartCoroutine(ResetWarningPanel());
    }

    IEnumerator ResetWarningPanel()
    {
        _warningText.SetActive(true);
        yield return new WaitForSeconds(2f);
        _warningText.SetActive(false);
    }
}
