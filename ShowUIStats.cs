using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShowUIStats : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI pointsText;
    public int points = 0;
    public int health;
    [SerializeField]TextMeshProUGUI healthText;
    
    private void Awake()
    {
        
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        SetText();
    }
    public void AddPoint()
    {
        points += 50;
        pointsText.text = points.ToString();
    }
    public void SetText()
    {
        health = Player.getPlayer.health;
        healthText.text = "HP: " + health.ToString();
    }
    public void ResetScores()
    {
        Destroy(gameObject);
    }
}
