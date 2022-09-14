using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMovement : MonoBehaviour
{
    //player
    public Rigidbody2D cow;

    //animation variable
    private Animator animate;

    //player movement jump and speed
    private float speed;
    private float vertical;
    private float horizontal;
    private bool jumping;
    private float jumpForce;
    private bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        //get cow player
        cow = gameObject.GetComponent<Rigidbody2D>();

        //get the animations
        animate = gameObject.GetComponent<Animator>();

        //initial start speeds
        //must put f after floats
        speed = 50f;
        jumping = false;
        jumpForce = 20f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //-1 = left, 0 = no key press, 1 = right
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        //set to run/idle animation
        animate.SetFloat("speed", Mathf.Abs(horizontal));

        //set to jump animation
        animate.SetFloat("jump", Mathf.Abs(vertical));

        //flip if moving other direction
        if(horizontal < 0 && !isRight){
            Flip();
        } else if (horizontal > 0 && isRight){
            Flip();
        }
    }

    void FixedUpdate(){

        //if right, move right...if left move left
        if(horizontal > 0.1f || horizontal < -0.1f){
            //horizontal*speed is x axis, 0f means do not move vertically
            cow.AddForce(new Vector2(horizontal * speed, 0f), ForceMode2D.Impulse);
            
        }

        //move player vertically
        if(!jumping && vertical > 0.1f){
            //vertical*jump force is y axis, 0f means do not move horizontally
            cow.AddForce(new Vector2(0f, vertical * jumpForce), ForceMode2D.Impulse);
        } 
    }

     //is the character in the air?
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Platform"){
            jumping = false;
        }
    }

    //if the cow jumps onto a platform 
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Platform"){
            jumping = true;
        }
    }

    //flip the character towards the direction he is moving
    void Flip(){
        isRight = !isRight;
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
