using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuScript : MonoBehaviour {

	public void PlayGame()
    {
        //SceneManager.LoadScene("Master"); // use this one it loades the master scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // load the next scene form the curren one

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }




}
