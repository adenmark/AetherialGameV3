using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProximity : MonoBehaviour {

    private Vector3 fireTo;
    public GameObject projectile;
    public Transform target;
    private Animator animator;
    //private float deathTimer;

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
                animator.SetTrigger("AetherAttack");
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
	}

    void Shoot()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        fireTo = new Vector3(targetPosition.x, targetPosition.y, 0f) - transform.position;

        GameObject Bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;

        Bullet.GetComponent<Rigidbody2D>().AddForce(fireTo.normalized * projectileSpeed);
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

            animator.SetTrigger("AetherDeath");
    }
}
