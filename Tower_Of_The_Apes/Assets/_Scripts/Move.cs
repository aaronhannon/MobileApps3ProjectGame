using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float acc = 0.02f;
    private float velocity;
    private float maxHeight = 1.0f;
    public bool grounded = true;
    public float jumpPower;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            grounded = true;
            rb.velocity = Vector2.zero;
        }
        
    }

    void FixedUpdate()
    {

        // if (rb2d.velocity.magnitude > maxSpeed)
        //   rb2d.velocity = rb2d.velocity.normalized * maxSpeed;

        //float horizontal = Input.GetAxis("Horizontal") * acceleration * Time.deltaTime;
        //float vertical = Input.GetAxis("Vertical") * acceleration * Time.deltaTime;
        
        if (Input.GetAxis("Horizontal")>0 || Input.GetAxis("Horizontal") < 0)
        {
            
            velocity += Input.GetAxis("Horizontal") * acc;
            
            if(Input.GetAxis("Horizontal") < 0 && velocity > 0)
            {

                velocity -= 0.1f;
                Debug.Log(velocity);
            }

            if (Input.GetAxis("Horizontal") > 0 && velocity < 0)
            {

                velocity += 0.1f;
                Debug.Log(velocity);
            }


        }

        if (Input.GetKeyDown("space") && grounded == true)
        {
            grounded = false;
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower));
        }

        transform.position = new Vector2(transform.position.x+velocity, transform.position.y);
        //Debug.Log("Velocity: " + velocity);
        //Debug.Log(transform.position.x.ToString());
    }
}
