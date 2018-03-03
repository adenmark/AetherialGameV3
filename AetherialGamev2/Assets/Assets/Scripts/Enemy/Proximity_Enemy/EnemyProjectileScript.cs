using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public Transform target;

    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -0, Vector3.forward);
    }

    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
            Die();
        }
        if (collision.gameObject.tag == "Scenery")
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}