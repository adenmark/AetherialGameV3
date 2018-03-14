using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Add-Ons")]

    public Transform teleportationExplosion;
    public GameObject Missile;
    public GameObject Nuke;
    public Transform missilePoint;
    public GameObject teleParticleEffect;

    private Transform player;
    private Rigidbody2D rb;
    private bool invincible = false;

    private Animator anim;
    private float deathTimer = 0;
    
    [Header("Attributes")]

    public float speed;
    public float invisibilityDuration;
    public float AetherPickupValue = 0.1f;

    [Header("Teleport")]
    public float teleportCooldown;
    public float teleportDelayTime;
    public float teleportCost;
    private float teleportCooldownTimer = 0;
    public AudioClip TeleportSound; //Adds option to designate a sound for the player teleport ability
    AudioSource audioSource;

    [Header("Missiles")]
    public float missileSwarmCount;
    private float missileCounter;
    public float rocketCost;

    [Header("Missiles")]
    private float nukeMeter;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat aetherBar;

    [Header("Audio")]
    public AudioClip DeathSound; //Adds option to designate a sound for the player death

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
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        TeleportCooldownFunction();

        if (health.CurrentVal <= 0)
        {
            SoundManager.instance.PlaySingle(DeathSound); //Plays the sound of the player's death explosion
            anim.SetTrigger("PlayerDeath");
            Destroy(GameObject.Find("Cannon"));
            deathTimer += Time.deltaTime;
            if (deathTimer >= 2.5)
            {
                Destroy(GameObject.Find("Canvas"));
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                Destroy(gameObject);
            }
        }

        // Teleport //
        if (Input.GetMouseButtonDown(1) && teleportCooldownTimer == 0)
        {
            anim.SetTrigger("PlayerDash");
            StartCoroutine(TeleportDelay());
            teleportCooldownTimer = teleportCooldown;
        }

        // Shooting the Missiles // 
        if (Input.GetKeyDown(KeyCode.Space) && aetherBar.CurrentVal >= 1)
        {
            InvokeRepeating("FireMissileSwarm", 0f, 0.15f);
            aetherBar.CurrentVal -= rocketCost;
        }

        // SHooting Da Nuke //
        if (Input.GetKeyDown(KeyCode.F) && nukeMeter == 1)
        {
            Instantiate(Nuke, missilePoint.position, Quaternion.identity);
            nukeMeter--;
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
                invincible = true;
                Invoke(methodName: "ResetInvinsibility", time: invisibilityDuration);
                Vector3 new_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                new_pos.z = teleport_transform.position.z;
                teleport_transform.position = new_pos;

                Instantiate(teleportationExplosion, player.position, Quaternion.identity);
                Instantiate(teleParticleEffect, player.position, Quaternion.identity);
                aetherBar.CurrentVal -= teleportCost;
                audioSource.PlayOneShot(TeleportSound, 0.7F);
                //SoundManager.instance.PlaySingle(TeleportSound); //Plays the sound of the player's Teleport ability 
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