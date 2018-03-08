using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissileLauncherScript : MonoBehaviour
{
    public GameObject Missile;
    public Transform missilePoint;
    public GameObject DamageParticle;
    private Transform target;

    [Header("Attributes")]

    public float missileCooldown;
    public float rotationSpeed;
    public float range;

    private float MissileCooldownTimer = 0;

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

        MissileFire();
        if (target != null && MissileCooldownTimer <= 0f && Vector2.Distance(transform.position, target.position) < range)
        {
            FireBossMissile();
            MissileCooldownTimer = missileCooldown;
        }
    }

    void MissileFire()
    {
        if (MissileCooldownTimer > 0)
        {
            MissileCooldownTimer -= Time.deltaTime;
        }

        if (MissileCooldownTimer < 0)
        {
            MissileCooldownTimer = 0;
        }
    }

    void FireBossMissile()
    {
        Instantiate(Missile, missilePoint.position, Quaternion.identity);
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
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
