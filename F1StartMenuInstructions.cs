using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class F1StartMenuInstructions : MonoBehaviour
{

    [SerializeField] Image aArrow;
    [SerializeField] Image dArrow;

    private void Start()
    {
        aArrow = GetComponentInChildren<Image>();
        //aArrow = GetComponent<Image>();
        dArrow = GetComponent<Image>();

        //aArrow.color = new Color(243, 129, 0, 1);
        //dArrow.color = new Color(243, 129, 0, 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            aArrow.color = new Color32(190, 125, 43,100);
        }
        else
        {
            aArrow.color = new Color32(243, 129, 0,100);
        }
        if (Input.GetKey(KeyCode.D))
        {
            dArrow.color = new Color32(190, 125, 43, 100);
        }
        else
        {
            dArrow.color = new Color32(243, 129, 0, 100);
        }
    }
}
