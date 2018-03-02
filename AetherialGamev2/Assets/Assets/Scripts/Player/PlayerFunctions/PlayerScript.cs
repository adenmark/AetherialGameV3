using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform teleportationExplosion;

    private Transform player;
    private Rigidbody2D rb;
    private float teleportCooldownTimer = 0;
    private bool invincible = false;
    private Animator animator;

    [Header("Attributes")]

    public float speed;
    public float teleportCooldown;
    public float teleportDelayTime;
    public float invisibilityDuration;

    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat aetherBar;

    private void Awake()
    {
        health.Initialize();
        aetherBar.Initialize();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        TeleportCooldownFunction();

        if (Input.GetMouseButtonDown(1) && teleportCooldownTimer == 0)
        {
            animator.SetTrigger("PlayerDash");
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
            }
        }
    }

    public void Damage()
    {
        if (!invincible)
        {
            invincible = true;
            Invoke(methodName: "ResetInvinsibility", time: invisibilityDuration);
            health.CurrentVal--;
            if (health.CurrentVal == 0)
            {
                animator.SetTrigger("PlayerDeath");   //caling the animation
                Destroy(gameObject, 5);
                //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }
    }

    void ResetInvinsibility()
    {
        invincible = false;
    }
}