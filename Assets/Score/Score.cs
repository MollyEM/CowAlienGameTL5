using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;

    // The score is initially set to 0 and is displayed as such.
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum;
    }

    // This portion is commented out until 

    /*
    // When the player collides with the hay, the score will update and the hay object will be destroyed.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Hay.tag == "MyHay")
        {
            ScoreNum += 100;
            Destroy(Hay.gameObject);
            MyscoreText.text = "Score" + ScoreNum;
        }
    } */
}
