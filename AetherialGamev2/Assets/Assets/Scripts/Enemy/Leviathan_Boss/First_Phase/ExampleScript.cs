using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public GameObject Projectile;
    public Transform firePoint;
    public GameObject DamageParticle;
    private Transform target;

    [Header("Attributes")]

    public float Cooldown;
    public float range;
    public float rotationSpeed;

    private float CooldownTimer = 0;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) < range)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        Fire();
        if (target != null && CooldownTimer <= 0f && Vector2.Distance(transform.position, target.position) < range)
        {
            FireBossMissile();
            CooldownTimer = Cooldown;
        }
    }

    void Fire()
    {
        if (CooldownTimer > 0)
        {
            CooldownTimer -= Time.deltaTime;
        }

        if (CooldownTimer < 0)
        {
            CooldownTimer = 0;
        }
    }

    void FireBossMissile()
    {
        Instantiate(Projectile, firePoint.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Instantiate(DamageParticle, transform.position, rotation: transform.rotation);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}