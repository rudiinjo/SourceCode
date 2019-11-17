using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class showWinningScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI EndScreen;
    [SerializeField]Button btn;    
    private void OnTriggerEnter(Collider other)
    {
        btn.gameObject.SetActive(true);
        EndScreen.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
