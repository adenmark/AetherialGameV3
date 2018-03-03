using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireScript : MonoBehaviour
{
    private Vector3 mouseDirection;

    public float fireRate;      // Fire Rate of the Cannon
    public float harpoonSpeed;      // Speed of Harpoon

    public GameObject Harpoon;
    public GameObject Missile;

    float timeToFire = 0;
    public Transform firePoint;
    public Transform missilePoint;

    private void Start()
    {
       
    }
    
    void Awake ()
    {
        firePoint = transform.Find("HarpoonSpawn");
        missilePoint = transform.Find("MissileSpawn");
    }
	
	void Update ()
    {
        // Shooting the Harpoon //
        if (fireRate == 0)                          // Is it a Single-Fire Weapon?
        {
            if (Input.GetMouseButtonDown(0))        // Left Click
            {
                FindShot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > timeToFire)      // If it is not a single button down?
            {
                timeToFire = Time.time + 1 / fireRate;
                FindShot();
            }
        }

        // Shooting the Missiles // 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireMissileSwarm();
        }
    }

    void FindShot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y); // Find Mouse Position

        mouseDirection = new Vector3(mousePosition.x, mousePosition.y, 0f) - transform.position;                                                          // Getting the position of the mouse

        GameObject Projectile = Instantiate(Harpoon, firePoint.position, Quaternion.identity) as GameObject;                                              // Creating the Harpoon at the position and rotating it
        Projectile.transform.up = mouseDirection;                                                                                                         // Rotates Shot right way

        Projectile.GetComponent<Rigidbody2D>().AddForce(mouseDirection.normalized * harpoonSpeed);   // Giving the Harpoon velocity when it came out, Problem here
    }

    void FireMissileSwarm()
    {
        GameObject Missile = Instantiate(this.Missile, missilePoint.position, Quaternion.identity) as GameObject;
    }
}
