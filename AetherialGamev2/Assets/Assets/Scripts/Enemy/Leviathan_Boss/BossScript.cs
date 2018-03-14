using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform player;

    public float speed;
    private float deadSpeed;

    private float Health = 1;

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
        deadSpeed = speed;
    }
	
	void Update ()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nuke")
        {
            speed -= deadSpeed;
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Damage();
        }
    }

    public void Damage()
    {
        Health--;
    }

    private void OnDestroy()
    {
        speed = 0;
    }
}
