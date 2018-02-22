using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLevelLoader : MonoBehaviour {

    public string levelToLoad;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


 
    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(levelToLoad);

                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Debug.Log("scene Master loaded");

            
            }

    }

      
}
