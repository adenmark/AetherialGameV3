using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public Transform player;
    public GameObject KillYourself;
    public float speed = 1f;

    private float Health = 1;
    private float whiteTimer = 0.2f;

    bool isMoving = true;

    private SpriteRenderer myRenderer;
    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;

    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used

        player = GameObject.FindWithTag("Player").transform;
    }
	
	void Update ()
    {
        if (player != null && isMoving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Nuke")
        {
            isMoving = false;
            Invoke("whiteSprite", 0.3f);
            Destroy(gameObject, 1.0f);
        }
    }

    private void OnDestroy()
    {
        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    void whiteSprite()
    {
        myRenderer.material.shader = shaderGUItext;
        myRenderer.color = Color.white;
    }
}
