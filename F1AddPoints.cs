using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class F1AddPoints : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    int points = 0;
    F1SoundManager soundManager;
    private void Start()
    {
        soundManager = FindObjectOfType<F1SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        points += 10;
        Destroy(collision.gameObject);
        text.text = points.ToString();
        soundManager.PlayAddPoints();
    }




}
