using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform player;

    public float speed;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
	
	void Update ()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
