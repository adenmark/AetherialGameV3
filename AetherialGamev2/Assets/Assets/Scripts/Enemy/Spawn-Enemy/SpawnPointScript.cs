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

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")                                              // The Triggerer == Player
        {
            InvokeRepeating("EnemySpawner", 0.5f, spawnRate);                               // Call function, Time Delay, and then SpawnRate

        }
    }

    void EnemySpawner()
    {
        Instantiate(EnemyProximity, enemyPosition.position, enemyPosition.rotation);        // Summon Enemy
    }







    //public GameObject EnemyProximity;
    //public Vector3 spawnValues;
    //public int hazardCount;
    //public float spawnWait;
    //public float startWait;
    //public float waveWait;

    //void Start()
    //{
    //    StartCoroutine(SpawnWaves());
    //}

    //IEnumerator SpawnWaves()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    while (true)
    //    {
    //        for (int i = 0; i < hazardCount; i++)
    //        {
    //            Vector3 spawnPosition = new Vector3(Random.Range(+spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
    //            Quaternion spawnRotation = Quaternion.identity;
    //            Instantiate(EnemyProximity, spawnPosition, spawnRotation);
    //            yield return new WaitForSeconds(spawnWait);
    //        }
    //        yield return new WaitForSeconds(waveWait);
    //    }
    //}
}
