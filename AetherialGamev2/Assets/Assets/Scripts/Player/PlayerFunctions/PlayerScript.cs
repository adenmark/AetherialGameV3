using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Add-Ons")]

    public Transform teleportationExplosion;
    public GameObject Missile;
    public Transform missilePoint;
    public AudioClip DeathSound;

    private Transform player;
    private Rigidbody2D rb;
    private float teleportCooldownTimer = 0;
    private bool invincible = false;

    private Animator anim;
    private float deathTimer = 0;
    
    [Header("Attributes")]

    public float speed;
    public float teleportCooldown;
    public float teleportDelayTime;
    public float invisibilityDuration;
	public AudioClip TeleportSound; //Adds option to designate a sound for the player teleport ability
    public float AetherPickupValue = 0.1f;

    [Header("Missiles")]
    public float missileSwarmCount;
    private float missileCounter;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat aetherBar;

    private void Awake()
    {
        health.Initialize();
        aetherBar.Initialize();
        missilePoint = transform.Find("MissileSpawn");
        missileCounter = missileSwarmCount;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        TeleportCooldownFunction();

        // Teleport //
        if (Input.GetMouseButtonDown(1) && teleportCooldownTimer == 0)
        {
            anim.SetTrigger("PlayerDash");
            //Cannon = this.gameObject.transform.GetChild(0);
            //Cannon.GetComponent<SpriteRenderer>().enabled = false;      //cant get the cannon to disapare during the animation and then appera again
            ////timer++;
            //if (timer > 5)
            //{
            //    Cannon.GetComponent<SpriteRenderer>().enabled = true;
            //}

            StartCoroutine(TeleportDelay());
            teleportCooldownTimer = teleportCooldown;
        }

        // Shooting the Missiles // 
        if (Input.GetKeyDown(KeyCode.Space) && aetherBar.CurrentVal >= 1)
        {
            InvokeRepeating("FireMissileSwarm", 0f, 0.2f);
            aetherBar.CurrentVal--;
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
    }

    void Teleport(Transform teleport_transform)
    {
        if (!invincible)
        {
            if (aetherBar.CurrentVal >= 1)
            {
                //mathf.clamp
                invincible = true;
                Invoke(methodName: "ResetInvinsibility", time: invisibilityDuration);
                Vector3 new_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                new_pos.z = teleport_transform.position.z;
                teleport_transform.position = new_pos;

                Instantiate(teleportationExplosion, player.position, Quaternion.identity);
                aetherBar.CurrentVal--;

                SoundManager.instance.PlaySingle(TeleportSound); //Plays the sound of the player's Teleport ability 
            }
        }
    }

    void FireMissileSwarm()
    {
        Instantiate(Missile, missilePoint.position, Quaternion.identity);
        --missileCounter;
        if (missileCounter == 0)
        {
            CancelInvoke("FireMissileSwarm");
            missileCounter = missileSwarmCount;
        }
    }

    public void Damage()
    {
        if (!invincible)
        {
            invincible = true;
            Invoke(methodName: "ResetInvinsibility", time: invisibilityDuration);
            health.CurrentVal--;
            if (health.CurrentVal <= 0)
            {
                anim.SetTrigger("PlayerDeath");                         //caling the animation
                Destroy(GameObject.Find("Cannon"));                         //destroys the childe of player - cannon
                SoundManager.instance.PlaySingle(DeathSound);               //Plays the AudioClip for player dying
                deathTimer++;
                if (deathTimer > 2.5)                                       //workes but i thinks it laggs?
                {
                    Destroy(GameObject.Find("Canvas"));
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                   Destroy(gameObject);
                }
            }
        }
        
    }

    void ResetInvinsibility()
    {
        invincible = false;
    }

    public void AetherPickup()
    {
        aetherBar.CurrentVal += AetherPickupValue;
    }
}