using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject DamageParticle;
    public GameObject DeathParticle;
    public GameObject aetherPickup;
    public Transform target;
    public GameObject EnemyType;

    [Header("Attributes")]

    private float spawnRange = 10;
    public float spawnRate;
    private float spawnCountdown;
    public float spawnCap = 7;
    public Transform enemyPosition;
    public float rotationSpeed;

    private float enemiesSpawned = 0;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) < spawnRange)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

        if (spawnCap > enemiesSpawned && Vector2.Distance(transform.position, target.position) < spawnRange && spawnCountdown <= 0f)
        {
            EnemySpawner();
            spawnCountdown = 1f / spawnRate;
        }
        spawnCountdown -= Time.deltaTime;
    }

    void EnemySpawner()
    {
        Instantiate(EnemyType, enemyPosition.position, enemyPosition.rotation);
        Instantiate(DamageParticle, position: transform.position, rotation: transform.rotation);
        enemiesSpawned++;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Instantiate(DamageParticle, position: transform.position, rotation: transform.rotation);
        }
    }

    void OnDestroy()
    {
        Instantiate(aetherPickup, transform.position, Quaternion.identity);
        Instantiate(DeathParticle, transform.position, Quaternion.identity);
        GetComponentInParent<ShieldScript>().Damage();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}
