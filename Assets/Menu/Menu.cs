using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(){
        //if the user clicks the play button, move to the game scene
        Debug.Log("Player clicked Start");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Task Screen 1", LoadSceneMode.Single);
    }

    public void TaskScreen1()
    {
        SceneManager.LoadScene("parallaxBackground 1", LoadSceneMode.Single);
    }

    public void DrBCMode()
    {
        //if the user clicks the Dr BC button, move to the special game scene
        Debug.Log("Player clicked Dr BC Mode");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Task Screen 2", LoadSceneMode.Single);
    }

    public void TaskScreen2()
    {
        SceneManager.LoadScene("Dr. BC Mode", LoadSceneMode.Single);
    }

    public void QuitGame(){
        //if the user clicks the quit button, the game will close.
        Debug.Log("Player Quit Game");
        Application.Quit();
    }
}
