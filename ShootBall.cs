using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 10f;
    public static ShootBall getShootBall;
    // Start is called before the first frame update
    void Start()
    {
        getShootBall = this;
        rb = GetComponent<Rigidbody2D>();
        GoBall();
    }



    public void GoBall()
    {
        transform.position =  Vector3.zero;
        float randomNumber = Random.Range(-1f, 1f);
        Debug.Log("Randomnumber " + randomNumber);
        if (randomNumber <= 0f)
        {
            rb.velocity = (new Vector2(speed, randomNumber * 10));
            //Debug.Log("Randomnumber " + GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            rb.velocity = (new Vector2(-speed, randomNumber * -10));
        }
    }


}
