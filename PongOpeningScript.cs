using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongOpeningScript : MonoBehaviour
{
    [SerializeField] GameObject ball;

    // Update is called once per frame
    void Update()
    {
        float pos = ball.transform.position.y;
        transform.position = new Vector2(transform.position.x, pos);
    }
}
