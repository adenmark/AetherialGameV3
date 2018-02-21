using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour
{
    public GameObject EnemyProximity;                                                       // What Time of Enemy

    public float spawnRate;                                                                 // How Often they Spawn
    public Transform enemyPosition;                                                         // The Position of the Enemy

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")                                              // The Triggerer == Player
        {
            InvokeRepeating("EnemySpawner", 0.1f, spawnRate);                               // Call function, Time Delay, and then SpawnRate
        }
    }

    void EnemySpawner()
    {
        Instantiate(EnemyProximity, enemyPosition.position, enemyPosition.rotation);        // Summon Enemy
    }
}