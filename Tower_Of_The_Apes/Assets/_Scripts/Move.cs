using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* TO DO!!
 * Win Condition
 * Menus 
 * settings
 * Write highscores to file
 * Read Highscores from File
 */

/* TO BE COMMITED!!
 * Platforms decay on a timer
 * Platforms move at certain player heights
 * Writing HighScore to file
 * End Game Condition inplemented
*/
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
    private float changeSpeed = 0.25f;
    private float platformCounter;
    private float highestPlatform;
    private GameObject floor;
    int counter = 0;
    Rigidbody2D rb;
    private bool gameOver = false;
    private bool reset = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        floor = GameObject.Find("Floor");

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("GROUND");
            grounded = true;
            inAir = false;
            jumpPower = 0.0f;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            // Debug.Log("COLLISION");

            if (transform.position.y > other.gameObject.transform.position.y)
            {
                platformCounter = other.gameObject.transform.position.y / 2;

                if (platformCounter > highestPlatform)
                {
                    highestPlatform = platformCounter;
                }
                Debug.Log("HIGH SCORE: " + highestPlatform);
            }

            if (transform.position.y> other.gameObject.transform.position.y)
            {
               // Debug.Log("OVER PLATFORM");
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


        if (gameOver == false)
        {
            if (highestPlatform > 5)
            {
                floor.GetComponent<BoxCollider2D>().enabled = false;
                floor.GetComponent<SpriteRenderer>().enabled = false;


                if (transform.position.y < floor.transform.position.y)
                {
                    gameOver = true;
                }
            }

            if (gameOver)
            {
                Debug.Log("GAME OVER!!!");
                FileHandler fh = new FileHandler();
                fh.WriteString("Name: Test Score: " + highestPlatform.ToString() + "\n");
                floor.GetComponent<BoxCollider2D>().enabled = true;
                floor.GetComponent<SpriteRenderer>().enabled = true;
                transform.position = new Vector2(1,5);
                //reset = true;
            }

            //WALL COLLISION
            if (transform.position.x < -11)
            {
                transform.position = new Vector2(-11, transform.position.y);
                velocity = 0.0f;
            }

            if (transform.position.x > 11)
            {
                transform.position = new Vector2(11, transform.position.y);
                velocity = 0.0f;
            }

            //KEYPRESSES
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

                //Debug.Log(velocity);
            }

            //ROTATION OF PLAYER
            if (grounded == false && maxJump == 1.0f)
            {
                // Debug.Log("ROTATING");
                if (velocity > 0)
                {
                    transform.Rotate(Vector3.back * 7);
                }
                else
                {
                    transform.Rotate(Vector3.forward * 7);
                }


            }

            //JUMP HIGHER AT A CERTAIN VELOCITY
            if ((velocity < -changeSpeed || velocity > changeSpeed) && grounded == true)
            {
                //Debug.Log("MAX JUMP");
                maxJump = 1.0f;
            }
            else if ((velocity > -changeSpeed || velocity < changeSpeed) && grounded == true)
            {
                maxJump = 0.5f;
            }

            //JUMP KEYPRESS
            if (Input.GetKeyDown("space") && grounded == true)
            {
                inAir = true;
                grounded = false;
            }

            if (inAir == true && jumpPower < maxJump)
            {
                //Debug.Log("HerE");
                jumpPower += 0.05f;
                transform.position = new Vector2(transform.position.x, transform.position.y + jumpPower);
            }

            transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
        }
    }

    public float getPlatformCounter()
    {
        return platformCounter;
    }
}