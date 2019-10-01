using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float acc = 0.02f;
    private float velocity;
    private float maxHeight = 1.0f;
    public bool grounded = true;
    private bool inAir = false;
    private float jumpPower = 0.0f;
    private float maxJump = 1.0f;
    private bool onPlatform = false;
    int counter = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            inAir = false;
            jumpPower = 0.0f;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            

            
            if (transform.position.y> other.gameObject.transform.position.y)
            {
                Debug.Log("OVER PLATFORM");
                jumpPower = 0.0f;
                grounded = true;
                inAir = false;
                counter = 0;
            }
            counter++;
            //jumpPower = 0.0f;
            //rb.velocity = Vector2.zero;
        }

    }

    void FixedUpdate()
    {

        // if (rb2d.velocity.magnitude > maxSpeed)
        //   rb2d.velocity = rb2d.velocity.normalized * maxSpeed;

        //float horizontal = Input.GetAxis("Horizontal") * acceleration * Time.deltaTime;
        //float vertical = Input.GetAxis("Vertical") * acceleration * Time.deltaTime;

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {

            velocity += Input.GetAxis("Horizontal") * acc;

            if (Input.GetAxis("Horizontal") < 0 && velocity > 0)
            {

                velocity -= 0.1f;
                //Debug.Log(velocity);
            }

            if (Input.GetAxis("Horizontal") > 0 && velocity < 0)
            {

                velocity += 0.1f;
                //Debug.Log(velocity);
            }

            Debug.Log(velocity);
        }

        if((velocity < -0.75f || velocity > 0.75f) && grounded==true)
        {
            Debug.Log("MAX JUMP");
            maxJump = 2.0f;
        }
        else if((velocity > -0.75f || velocity < 0.75f) && grounded == true)
        {
            maxJump = 1.0f;
        }

        if (Input.GetKeyDown("space") && grounded == true)
        {
            inAir = true;
            grounded = false;
        }

        if (inAir == true && jumpPower < maxJump)
        {
            //Debug.Log("HerE");
            jumpPower+=0.3f;
            transform.position = new Vector2(transform.position.x, transform.position.y + jumpPower);
        }

        transform.position = new Vector2(transform.position.x + velocity,transform.position.y);

    }

}