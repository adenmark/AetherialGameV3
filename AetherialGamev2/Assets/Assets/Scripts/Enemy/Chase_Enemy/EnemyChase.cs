using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public GameObject aetherPickup;

    public float speed;
	public AudioClip SkySlugSpawnSound;
	public AudioClip SkySlugExplosion;
    public GameObject explosion;
    public GameObject explosionEffect;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
		SoundManager.instance.PlaySingle(SkySlugSpawnSound);
    }
	
	void Update ()
    {
        RotateToPlayer();
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else // Can be removed, just cute <3
        {
            Destroy(gameObject);
        }
    }

    void RotateToPlayer()
    {
        if (player != null)
        {
            transform.LookAt(player.position);

            transform.Rotate(new Vector3(0, 90, 0), Space.Self);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(aetherPickup, transform.position, Quaternion.identity);
        SoundManager.instance.PlaySingle(SkySlugExplosion);
    }
}
