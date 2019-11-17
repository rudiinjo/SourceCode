using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject explosionParticles;
    [SerializeField] AudioClip deathClip;
    ShowUIStats UIstats;
    AudioSource audioSource;
    SpriteRenderer sprite;
    private void Start()
    {
        UIstats = FindObjectOfType<ShowUIStats>();
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        audioSource = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CountDownAndShoot(); 
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, new Vector3(transform.position.x,transform.position.y- sprite.bounds.extents.x,transform.position.z), Quaternion.identity)as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        audioSource.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer){ return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position,volume:1f);
            Destroy(Instantiate(explosionParticles, transform.position, Quaternion.identity), 1f);
            UIstats.AddPoint();
        }
    }
}
