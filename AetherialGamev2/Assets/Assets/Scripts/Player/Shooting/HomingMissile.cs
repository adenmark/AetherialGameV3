using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    public GameObject missileExplosion;
    public GameObject missileDamage;
    public string enemyTag = "Enemy";
    public AudioClip MissileLaunch;
    public AudioClip MissileExplosion;


    [Header("Missile Attributes")]

    public float missileSpeed;
    public float rotateSpeed;
    public float missileRange;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        SoundManager.instance.PlaySingle(MissileLaunch);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= missileRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * missileSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<HealthScript>().Damage(); // SOmething wrong with this
            Destroy(gameObject);
        }
        if (collision.CompareTag("Shield"))
        {
            collision.GetComponent<HealthScript>().Damage();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(missileExplosion, transform.position, transform.rotation);
        Instantiate(missileDamage, transform.position, Quaternion.identity);
        SoundManager.instance.PlaySingle(MissileExplosion);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, missileRange);
    }
}
