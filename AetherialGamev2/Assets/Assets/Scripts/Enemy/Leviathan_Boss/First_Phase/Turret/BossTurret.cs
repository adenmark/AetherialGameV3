using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
{
    public GameObject Projectile;
    public Transform firePoint;
    public GameObject DamageParticle;
    public GameObject DeathParticle;
    public GameObject AetherPickup;
    private Transform target;
    private Vector3 fireTo;

    [Header("Attributes")]

    public float Cooldown;
    public float range;
    public float rotationSpeed;
    public float speed;

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
            Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        Fire();
        if (target != null && CooldownTimer <= 0f && Vector2.Distance(transform.position, target.position) < range)
        {
            FireBossTurret();
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

    void FireBossTurret()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        fireTo = new Vector3(targetPosition.x, targetPosition.y, 0f) - transform.position;

        GameObject Bullet = Instantiate(Projectile, firePoint.transform.position, transform.rotation) as GameObject;

        Bullet.GetComponent<Rigidbody2D>().AddForce(fireTo.normalized * speed);
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

    private void OnDestroy()
    {
        Instantiate(AetherPickup, transform.position, Quaternion.identity);
        GetComponentInParent<ShieldScript>().Damage();
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
