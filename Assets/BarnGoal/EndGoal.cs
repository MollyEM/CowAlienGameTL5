using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    private bool gotKey = false;

    void OnTriggerEnter2D(Collider2D collision){
        
        //if trigger on key, then destroy key and set bool got key to true
        if(collision.gameObject.tag == "Key"){
            gotKey = true;

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Finish" && gotKey){

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
