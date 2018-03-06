using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherScript : MonoBehaviour
{
    private Transform player;

    public float speed;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            trigger.GetComponent<PlayerScript>().AetherPickup();
            Destroy(gameObject);
        }
    }
}
