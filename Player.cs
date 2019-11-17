using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 14f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringPeriod = 2f;
    [SerializeField] AudioClip deathSound;

    public static Player getPlayer;

    public int health = 200;
    float xmin = -3.15f;
    float xmax=3.15f;

    Coroutine firingCoroutine;
    SpriteRenderer sprite;
    AudioSource audioSource;
    ShowUIStats UIstats;
    // Start is called before the first frame update
    private void Awake()
    {
        getPlayer = this;
    }
    void Start()
    {
        UIstats = FindObjectOfType<ShowUIStats>();
        UIstats.SetText();
        sprite = GetComponent<SpriteRenderer>(); //Set the reference to our SpriteRenderer component
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        Move();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, new Vector2(transform.position.x,transform.position.y+sprite.bounds.extents.y), Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            audioSource.Play();
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health = 0;
            UIstats.SetText();
            Destroy(gameObject);
            FindObjectOfType<LoadScenes>().LoadGameOver();
            return;
        }
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
            UIstats.SetText();
            FindObjectOfType<LoadScenes>().LoadGameOver();
        }
        UIstats.SetText();
    }


    private void Move()
    {
        var deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x+deltaX,xmin,xmax );
        transform.position = new Vector2(newXPos, transform.position.y);
    }

}
