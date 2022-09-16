using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // String that will be displayed
    public Text MyscoreText;

    // Total points
    private int ScoreNum;

    // 
    private bool alreadyScored;
    [SerializeField] private AudioSource collectionSoundEffect;

    // The score is initially set to 0 and is displayed as such.
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum;
    }
    
    // When the player collides with the hay the score will update and the hay object will be destroyed.
    private void OnTriggerEnter2D(Collider2D Hay)
    {
        if(Hay.tag == "MyHay")
        {
            if (alreadyScored)
                return;

            alreadyScored = true;

            // Play sound effect
            collectionSoundEffect.Play();

            // Remove hay object
            Destroy(Hay.gameObject);

            // Update score
            ScoreNum += 100;

            // Update text that is displayed
            MyscoreText.text = "Score: " + ScoreNum;

            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.05f);
        alreadyScored = false;
    }
}