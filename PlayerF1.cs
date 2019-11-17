using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerF1 : MonoBehaviour
{

    float xPos;
    F1LoadScenes f1LoadScenes;
    F1SoundManager soundManager;
    // Update is called once per frame
    private void Start()
    {
        soundManager = FindObjectOfType<F1SoundManager>();
        f1LoadScenes = FindObjectOfType<F1LoadScenes>();
        xPos = transform.position.x;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
             xPos = Mathf.Clamp(transform.position.x -0.8f,-0.6f,1f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            xPos = Mathf.Clamp(transform.position.x + 0.8f, -0.6f, 1f);
        }
        Vector3 pos = new Vector3(xPos, transform.position.y, transform.position.z);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        f1LoadScenes.LoadGameOver();
        soundManager.PlayDeathSound();
    }
}
