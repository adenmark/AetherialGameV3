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

    public void LoadCredits()
    {
        //SceneManager.LoadScene("Credits", LoadSceneMode.Single); //loads the credits scene

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); // load the credits scene, only if you are in the main menu!

    }

    public void ReturnToMenu()
    {
        //SceneManager.LoadScene("Credits", LoadSceneMode.Single); //loads the credits scene

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4); // load the main menu scene, only if you are in the credits scene!

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }




}
