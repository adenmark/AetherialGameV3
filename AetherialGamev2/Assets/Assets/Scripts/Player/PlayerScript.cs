﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform player;                                                           // Set up a place to Store Player Position, Rotation, and Scale.
    private Rigidbody2D rb;

    public float speed;
    public float health;
    public float aether;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;                  // Get the Data to Store in Transform player
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetMouseButtonDown(1))                                                // Right Click to Teleport
        {
            Teleport(player);
        }
    }

    void Teleport(Transform teleport_transform)
    {
        if (aether >= 1)                                                                // Make sure we can't Teleport without Aether
        {
            Vector3 new_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);      // Makes the Position == Mouse Position
            new_pos.z = teleport_transform.position.z;                                  // Makes sure the Z position is still whatever it was before Teleportation
            teleport_transform.position = new_pos;                                      // 
            aether--;                                                                   // Reduces Aether by 1
        }
    }

    public void Damage()
    {
        health--;

        /*if (health == 1)
        {
            Destroy(gameObject);
        }*/

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}