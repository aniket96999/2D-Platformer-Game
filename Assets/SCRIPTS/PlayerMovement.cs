using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 10f;
    public float speed = 50f;
    private float translation;
    private Animator anim;
    private Rigidbody2D rb; // Declare the Rigidbody2D here

    


    public LayerMask whatIsGround;
    public Transform groundPosition;
    public bool Grounded = true;

    //public float getXpos
    //{
    //    get
    //    {
    //        return transform.position.x;
    //    }
    //}

    //public float getYpos
    //{
    //    get
    //    {
    //        return transform.position.y;
    //    }
    //}
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();

        }
    }



    void FixedUpdate()
    {
        
        //TurnPlayer();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            translation = Input.GetAxisRaw("Horizontal");
        }

        rb.linearVelocity = new Vector2(translation * Time.deltaTime * speed, rb.linearVelocity.y);

        // rb.velocity = new Vector2(translation * speed * Time.deltaTime, rb.velocity.y);


        if (translation > 0 || translation < 0)
        {
            anim.SetFloat("speed", 1);
        }
        if (translation == 0)
        {
            anim.SetFloat("speed", 0);
        }

        TurnPlayer(translation); // Flip prefab based on movement

    }

    
    
    void TurnPlayer(float horizontalInput)
{
        if (horizontalInput > 0)
        {
        // Facing right
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
        // Facing left
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
}


    bool isGrounded()
    {
        if (Physics2D.OverlapCircle(groundPosition.position, 0.3f, whatIsGround))
        {
            return true;
        }
        return false;
    }
    public void jump()
    {
        if (!isGrounded())
        {
            return;
        }
        else
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }


void OnCollisionEnter2D(Collision2D col)
{
    if (col.gameObject.tag == "Enemy")
    {
        /*if (isDead)
            return;

        anim.SetTrigger("death");
        isDead = true;*/
    }
}


    public void OnPointerEnter_Right()
    {
	translation = 1;
    }

    public void OnPointerExit()
    {
	translation = 0;
    }

    public void OnPointerEnter_Left()
    {
	translation = -1;
    }


}