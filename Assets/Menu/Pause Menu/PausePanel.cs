using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pause;
    //This will open the pause screen with help instructions and pause the game

    public void OpenPauseMenu(){
        if(pause != null){

            //is the menu activated
            bool helpActive = pause.activeSelf;

            //if the menu is not visible, make it visible visa versa
            if(helpActive == false){
                pause.SetActive(true);
                //pause the game
                Time.timeScale = 0f;

            } else {
                pause.SetActive(false);
                //unpause game
                Time.timeScale = 1f;
            }

            
            
        }
    }
}
