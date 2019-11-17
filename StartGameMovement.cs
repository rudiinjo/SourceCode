using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMovement : MonoBehaviour
{
    float xMov = 0.15f;
    float xmin=-3.15f;
    float xmax=3.15f;
    float ymin;
    float ymax;
    float time;
    float firingTime;
    [SerializeField] GameObject laserPrefab;
    float projectileSpeed = 20f;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x+-sprite.bounds.extents.x <= xmin || transform.position.x+ sprite.bounds.extents.x >= xmax)
        {
            xMov *= -1;
        }
        Vector3 pos = new Vector3(transform.position.x + xMov, transform.position.y, transform.position.z);
        transform.position = pos;
        time -= Time.deltaTime;
        firingTime -= Time.deltaTime;
        if (time <= 0)
        {
            xMov *= -1;
            GetNewTime();
        }

        if (firingTime <= 0)
        {
            Fire();
            GetFiringTime();
        }

    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
    }

    private void GetFiringTime()
    {
        firingTime = Random.Range(0.5f, 1f);
    }

    private void GetNewTime()
    {
        time = Random.Range(0.5f, 1.5f);
    }

}
