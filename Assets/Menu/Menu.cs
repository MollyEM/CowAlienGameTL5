using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame(){
        //if the user clicks the play button, move to the game scene
        Debug.Log("Player clicked Start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame(){
        //if the user clicks the quit button, the game will close.
        Debug.Log("Player Quit Game");
        Application.Quit();
    }
}
