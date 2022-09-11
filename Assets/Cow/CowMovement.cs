using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    //player
    private Rigidbody2D cow;

    //player movement jump and speed
    private float speed;
    private float vertical;
    private float horizontal;
    private bool jumping;
    private float jumpForce;



    // Start is called before the first frame update
    void Start()
    {
        //get cow player
        cow = gameObject.GetComponent<Rigidbody2D>();

        //initial start speeds
        //must put f after floats
        speed = 3f;
        jumping = false;
        jumpForce = 60f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //-1 = left, 0 = no key press, 1 = right
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
       
    }

    void FixedUpdate(){

        //if right, move right...if left move left
        if(horizontal > 0f || horizontal < 0f){
            //horizontal*speed is x axis, 0f means do not move vertically
            cow.AddForce(new Vector2(horizontal * speed, 0f), ForceMode2D.Impulse);
        }

        //move player vertically
        if(jumping && vertical > 0f){
            //vertical*jump force is y axis, 0f means do not move horizontally
            cow.AddForce(new Vector2(0f, vertical * jumpForce), ForceMode2D.Impulse);
        }

        //is the character in the air?
        void OnTriggerEnter2D(Collider2D collision){
            if(collision.gameObject.tag == "Platform"){
                jumping = false;
            }
        }

        void OnTriggerExit2D(Collider2D collision){
            if(collision.gameObject.tag == "Platform"){
                jumping = true;
            }
        }
    }
}
