using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AetherStar : MonoBehaviour
{
    private Transform player;
    public GameObject AetherPickupEffect;

    public float speed;
    public float coolDown;
    public float Angle;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start ()
    {
        player = GameObject.FindWithTag("Player").transform;
        posOffset = transform.position;
    }
	
	void Update ()
    {
        RotateLeft();

        coolDown -= Time.deltaTime;
        if (coolDown >= 0)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }

        if (player != null && coolDown <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.forward * -Angle);
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(AetherPickupEffect, transform.position, Quaternion.identity);
    }
}
