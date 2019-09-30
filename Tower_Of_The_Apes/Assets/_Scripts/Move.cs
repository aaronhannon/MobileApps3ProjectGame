using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float acc = 0.02f;
    private float velocity;
    void Start()
    {
       
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

        transform.position = new Vector2(transform.position.x+velocity, transform.position.y);
        //Debug.Log("Velocity: " + velocity);
        //Debug.Log(transform.position.x.ToString());
    }
}
