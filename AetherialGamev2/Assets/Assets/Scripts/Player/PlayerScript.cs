using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform teleportationExplosion;

    private Transform player;                                                           // Set up a place to Store Player Position, Rotation, and Scale.
    private Rigidbody2D rb;
    private float teleportCooldownTimer = 0;

    public float speed;
    public float aether;
    public float teleportCooldown;
    public float teleportDelayTime;

    [SerializeField]        //remove after testing serializedfield
    private Stat health;

    [SerializeField]        //remove after testing  serializedfield
    private Stat aetherBar;

    private void Awake()
    {
        health.Initialize();
        aetherBar.Initialize();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;                  // Get the Data to Store in Transform player
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        TeleportCooldownFunction();

        if (Input.GetMouseButtonDown(1) && teleportCooldownTimer == 0)                  // Right Click to Teleport
        {
            StartCoroutine(TeleportDelay());
            teleportCooldownTimer = teleportCooldown;
        }
    }

    void TeleportCooldownFunction()
    {
        if (teleportCooldownTimer > 0)
        {
            teleportCooldownTimer -= Time.deltaTime;
        }

        if (teleportCooldownTimer < 0)
        {
            teleportCooldownTimer = 0;
        }
    }

    IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(teleportDelayTime);                             // How Long we wait
        Teleport(player);
        Instantiate(teleportationExplosion, player.position, Quaternion.identity);
    }

    void Teleport(Transform teleport_transform)
    {
        if (aether >= 1)                                                                // Make sure we can't Teleport without Aether
        {
            //mathf.clamp
            Vector3 new_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);      // Makes the Position == Mouse Position
            new_pos.z = teleport_transform.position.z;                                  // Makes sure the Z position is still whatever it was before Teleportation
            teleport_transform.position = new_pos;
            aether--;                                                                   // Reduces Aether by 1

            aetherBar.CurrentVal--;                                                     // decresing the eather bar
        }
    }

    public void Damage()
    {
        health.CurrentVal--;                                                            //health bar decras on damage
        if (health.CurrentVal == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}