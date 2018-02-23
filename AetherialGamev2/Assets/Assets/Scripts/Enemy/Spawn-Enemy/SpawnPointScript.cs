using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject EnemyType;                                                            // What Time of Enemy
    public GameObject DamageParticle;
    public Transform particlePosition;

    public float spawnRate;                                                                 // How Often they Spawn
    public float spawnCap;                                                                  // How Many Will Spawn before Death
    public Transform enemyPosition;                                                         // The Position of the Enemy

    private float enemiesSpawned = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")                                                 // The Triggerer == Player
        {
            InvokeRepeating("EnemySpawner", time: 0.0f, repeatRate: spawnRate);                 // Call function, Time Delay, and then SpawnRate
            Destroy(gameObject, spawnRate * spawnCap);
        }
    }

    void EnemySpawner()
    {
        if (enemiesSpawned <= spawnCap)
        {
            Instantiate(EnemyType, enemyPosition.position, enemyPosition.rotation);                                 // Summon Enemy
            Instantiate(DamageParticle, position: particlePosition.position, rotation: particlePosition.rotation);
            enemiesSpawned++;
        }
    }
}