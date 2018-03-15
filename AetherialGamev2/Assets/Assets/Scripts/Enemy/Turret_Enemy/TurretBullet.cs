using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public AudioClip TurretFireSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(TurretFireSound, 0.7F);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
            Destroy(gameObject);
        }
        if (collision.CompareTag("Scenery"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        
    }
}
