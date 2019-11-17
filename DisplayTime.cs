using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayTime : MonoBehaviour
{
    public int Minutes = 0;
    public int Seconds = 0;
    public static DisplayTime getDisplayTime;
    private TextMeshProUGUI m_text;
    public float m_leftTime;

    private void Awake()
    {
        getDisplayTime = this;
        m_text = GetComponent<TextMeshProUGUI>();
        m_leftTime = GetInitialTime();
    }

    private void Update()
    {
        if (m_leftTime > 0f)
        {
            //  Update countdown clock
            m_leftTime -= Time.deltaTime;
            Minutes = GetLeftMinutes();
            Seconds = GetLeftSeconds();

            //  Show current clock
            if (m_leftTime > 0f)
            {
                m_text.text = Minutes + ":" + Seconds.ToString("00");
            }
            else
            {
                //  The countdown clock has finished
                m_text.text = "00:00";
                SceneManager.LoadScene("PongYouWon");
               
                
            }
        }
    }

    private float GetInitialTime()
    {
        return Minutes * 60f + Seconds;
    }

    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(m_leftTime / 60f);
    }

    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(m_leftTime % 60f);
    }
    
}
