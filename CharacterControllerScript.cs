<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private Animator anim;
    Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float maxSpeed = 10f; 
    public float verticalImpulse; 
    private bool isFacingRight = true;
    float speedX; 
    private bool isGrounded = false;
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
        
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if(move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();

        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
    }

    private void Flip() //you have to change that
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
    }
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float maxSpeed = 10f; 
    private bool isFacingRight = true;
    private Animator anim;
    Rigidbody2D rb;
    float speedX; 
    bool isGrounded;
    public float verticalImpulse; 


	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if(move > 0 && !isFacingRight)
            Flip();
        else if (move < 0 && isFacingRight)
            Flip();
    

      /* anim.Play("Idle", 0, 0.25f);
        if (Input.GetKey(KeyCode.A)) {
            speedX = -horizontalSpeed;
            anim.Play("Run", 0, 0.25f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            anim.Play("Run", 0, 0.25f);
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(1);
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
    }
>>>>>>> d819e5d8c054a4da05865be4a21d39afc5f39621
}