using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject EnemyType;                                                            // What Time of Enemy
    public GameObject DamageParticle;
    public Transform target;
    public Transform particlePosition;

    [Header("Attributes")]

    public float spawnRange;
    public float spawnRate;
    private float spawnCountdown;
    public float spawnCap;
    public Transform enemyPosition;

    private float enemiesSpawned = 0;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
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
            Instantiate(DamageParticle, position: particlePosition.position, rotation: particlePosition.rotation);
            enemiesSpawned++;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }
}