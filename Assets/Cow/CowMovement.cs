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
    //private float velocity;
    private bool isRight;
    //private float fallMultiplier = 2.5f;
    //private float jumpMultiplier = 2f;

    //player jump sound effect
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;

    //player health bar
    public int maxHealth = 16;
    public int currentHealth;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        //get cow player
        cow = gameObject.GetComponent<Rigidbody2D>();

        //get the animations
        animate = gameObject.GetComponent<Animator>();

        //initial start speeds
        //must put f after floats
        speed = 0.35f;
        jumping = false;
        jumpForce = 8.5f;
        //velocity = jumpForce;
        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
        //animate.SetFloat("jump", vertical);

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
            jumpSoundEffect.Play();
            //cow.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            cow.AddForce(new Vector2(0f, vertical * jumpForce), ForceMode2D.Impulse);
            //transform.Translate(new Vector3(0f, velocity, 0f) * Time.deltaTime);
            //cow.velocity = Vector2.up * jumpForce;
        } 
    }

     //is the character in the air? Did a bullet hit the character?
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Platform"){
            jumping = false;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage(4);
            Debug.Log(currentHealth);
            healthBar.SetHealth (currentHealth);
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

    void TakeDamage(int damage)
    {
        hurtSoundEffect.Play();
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
