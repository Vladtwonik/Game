using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private Animator anim;
    Rigidbody2D rb;
    public Vector2 moveVector;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float maxSpeed = 10f; 
    public float verticalImpulse; 
    private bool isFacingRight = true;
    float speedX; 
    private bool isGrounded = false;
    //private bool Performed_Jump = false;
    private float groundRadius = 0.2f;

	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	private void FixedUpdate()
    {   
        LayerMask whatIsGround = LayerMask.GetMask("Ground");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); 
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("vSpeed", rb.velocity.y);
        if (!isGrounded)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.P) == false){
            return;
        }
        
        float move = Input.GetAxis("Horizontal");//GetAxis - полчить ось, по которой передвигаем объект
        anim.SetFloat("Speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        moveVector.x = Input.GetAxis("Horizontal");
        Reflect();

        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
           // Perform();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            anim.SetBool("Pain", true);
        }
    }
    
    void Reflect()
    {
        if ((moveVector.x > 0 && !isFacingRight) || (moveVector.x < 0 && isFacingRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            isFacingRight = !isFacingRight;//меняем флажок на правильное направление
        }
    }

    /*private void Perform()
    {
        anim.SetBool("Performed_Jump", false);

    }*/

    /*private void Flip() //you have to change that
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
    }*/
}