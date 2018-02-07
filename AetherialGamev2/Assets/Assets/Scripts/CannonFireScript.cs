using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireScript : MonoBehaviour
{

    private Vector3 mouseDirection;

    public float fireRate = 0;      // Fire Rate of the Cannon
    public float damage = 1;        // Damage of the Harpoons, for now they are 1
    public LayerMask whatToHit;      // We use this to make sure we don't shoot things we don't want to hit

    public GameObject Harpoon;
    public Transform HarpoonSpawn;

    float timeToFire = 0;
    public Transform firePoint;

    private void Start()
    {
    }

    void Awake ()
    {
        firePoint = transform.Find("HarpoonSpawn");     // Will find the point at which Harpoons will spawn
        if (firePoint == null)      // Standard Error Checker
        {
            Debug.LogError("No Fire Point? WHAT!!!");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {


        if (fireRate == 0)      // Is it a Single-Fire Weapon?
        {
            if (Input.GetMouseButtonDown(0))        // Left Click
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > timeToFire)      // If it is not a single button down?
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition) .y); // Used to do a Raycast
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);    // Taking the point on the tip of our cannon and making it the position of a Vector2
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit);    // Saying where the Harpoon should go

        mouseDirection = new Vector3(mousePosition.x, mousePosition.y, 0f) - transform.position;

        GameObject Projectile = Instantiate(Harpoon, HarpoonSpawn.position, Quaternion.identity);
        Projectile.transform.up = mouseDirection;

        Projectile.GetComponent<Rigidbody2D>().AddForce(mouseDirection * 10);

        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition) *100, Color.cyan);      // Some cool shit on drawing lines on what to hit
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage.");
        }
    }
}
