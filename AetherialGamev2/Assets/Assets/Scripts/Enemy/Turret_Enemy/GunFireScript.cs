using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour
{
    public GameObject TurretBullet;
    public Transform target;
    private Vector3 fireTo;

    [Header("Attributes")]

    public float range;
    public float fireRate;
    public float bulletSpeed;
    private float fireCountdown = 0f;

    [Header("Unity Setup")]

    public float rotationSpeed;

    void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update ()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        if (fireCountdown <= 0f && Vector2.Distance(transform.position, target.position) < range)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        fireTo = new Vector3(targetPosition.x, targetPosition.y, 0f) - transform.position;

        GameObject Bullet = Instantiate(TurretBullet, transform.position, Quaternion.identity) as GameObject;

        Bullet.GetComponent<Rigidbody2D>().AddForce(fireTo.normalized * bulletSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
