﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximity : MonoBehaviour {

    private Vector3 fireTo;
    public GameObject projectile;
    public GameObject aetherPickup;
    public Transform target;
    private Animator animator;
	public AudioClip AetherRayShot; //Adds the option to input an audioclip to be used when the enemy fires, add sound in Unity Inspector
    //private float deathTimer;
    AudioSource audioSource;

    [Header("Enemy Attributes")]

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    [Header("Projectile Attribute")]

    private float fireCountdown;
    public float fireRate;
    public float projectileSpeed;

    void Start ()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        RotateToPlayer();

        if (target != null) // Temporary Fix
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
            }

            if (fireCountdown <= 0f)
            {
                audioSource.PlayOneShot(AetherRayShot, 0.7F); //Plays audio for the enemy shooting its projectile
                animator.SetTrigger("AetherAttack");
                Shoot();
                fireCountdown = 1f / (fireRate -= Random.Range(.01f, .1f));
            }

            fireCountdown -= Time.deltaTime;
        }
	}

    void Shoot()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        fireTo = new Vector3(targetPosition.x, targetPosition.y, 0f) - transform.position;

        GameObject Bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        //Bullet.transform. = target.position;

        Bullet.GetComponent<Rigidbody2D>().AddForce(fireTo.normalized * projectileSpeed);
		//SoundManager.instance.PlaySingle(AetherRayShot);	//Plays audio for the enemy shooting its projectile
    }

    void RotateToPlayer()
    {
        if (target != null)
        {
            transform.LookAt(target.position);

            transform.Rotate(new Vector3(0, 90, 0), Space.Self);
        }
    }

    void OnDestroy()
    {
        Instantiate(aetherPickup, transform.position, Quaternion.identity);
        animator.SetTrigger("AetherDeath");
    }
}
