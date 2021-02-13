<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public float horizontalSpeed;
    float speedX; 
    public float verticalImpulse; 
    bool isGrounded;
    Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() 
    {
        anim.Play("Idle", 0, 0.25f);
        if (Input.GetKey(KeyCode.A)) {
            speedX = -horizontalSpeed;
            anim.Play("Run", 0, 0.25f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            anim.Play("Run", 0, 0.25f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public float horizontalSpeed;
    float speedX; 
    public float verticalImpulse; 
    bool isGrounded;
    Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() 
    {
        anim.Play("Idle", 0, 0.25f);
        if (Input.GetKey(KeyCode.A)) {
            speedX = -horizontalSpeed;
            anim.Play("Run", 0, 0.25f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
            anim.Play("Run", 0, 0.25f);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

}
>>>>>>> d819e5d8c054a4da05865be4a21d39afc5f39621
