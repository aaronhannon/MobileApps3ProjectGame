using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Move : MonoBehaviour
{
    private float acc = 0.02f;
    private float velocity;
    private float maxHeight = 1.0f;
    public bool grounded = true;
    private bool inAir = false;
    private int doubleJump = 0;
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
    bool wallJump = false;
    private bool paused = false;
    FileHandler fh;
    GameObject inputCanvas;
    GameObject pausedCanvas;
    GameObject textObject;
    TMP_Text scoretext;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fh = new FileHandler();
        floor = GameObject.Find("Floor");
        inputCanvas = GameObject.Find("InputCanvas");
        inputCanvas.active = false;

        pausedCanvas = GameObject.Find("PausedCanvas");
        pausedCanvas.active = false;


        textObject = GameObject.Find("Score");
        scoretext = textObject.GetComponent<TMP_Text>();
        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("GROUND");
            grounded = true;
            inAir = false;
            jumpPower = 0.0f;
            doubleJump = 0;
            wallJump = false;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            // Debug.Log("COLLISION");

            if (transform.position.y > other.gameObject.transform.position.y)
            {
                
                platformCounter = Mathf.Round(other.gameObject.transform.position.y / 4f);

                if (platformCounter > highestPlatform)
                {
                    highestPlatform = platformCounter;
                    scoretext.text = "YOUR SCORE: " + highestPlatform.ToString();
                }
                
            }

            if (transform.position.y> other.gameObject.transform.position.y)
            {
               // Debug.Log("OVER PLATFORM");
                jumpPower = 0.0f;
                grounded = true;
                inAir = false;
                counter = 0;
                doubleJump = 0;
                wallJump = false;
            }
            counter++;

        }
        
    }

    void FixedUpdate()
    {


        if (gameOver == false)
        {

            if (Input.GetKeyUp("escape"))
            {
                Debug.Log("ESC Pressed");
                if (paused == false)
                {
                    Debug.Log("Paused");
                    //Time.timeScale = 0.0f;
                    paused = true;
                    velocity = 0.0f;
                    pausedCanvas.active = true;
                }
                else
                {
                    Debug.Log("UnPaused");
                    //Time.timeScale = 1.0f;
                    paused = false;
                    pausedCanvas.active = false;

                }

                



            }

            if (paused == true)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }

            if (paused == false)
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
                    
                    inputCanvas.active = true;
                    GameObject winnerText = GameObject.Find("Winner");
                    winnerText.active = false;

                    //fh.WriteString("Aaron",highestPlatform.ToString());
                    floor.GetComponent<BoxCollider2D>().enabled = true;
                    //floor.GetComponent<SpriteRenderer>().enabled = true;
                    transform.position = new Vector2(1, 5);
                    //reset = true;
                }

                if(highestPlatform >= 95)
                {
                    Debug.Log("WINNER!!");

                    
                    inputCanvas.active = true;
                    GameObject gameoverText = GameObject.Find("Gameover");
                    gameoverText.active = false;
                    

                }

                //WALL COLLISION
                if (transform.position.x < -11)
                {
                    transform.position = new Vector2(-11, transform.position.y);
                    velocity = 0.0f;
                    //Debug.Log("Wall Collision");
                }

                if (transform.position.x > 11)
                {

                    transform.position = new Vector2(11, transform.position.y);
                    velocity = 0.0f;

                }

                if (transform.position.x > 10 || transform.position.x < -10)
                {

                    //Debug.Log("Wall Collision");
                    if (Input.GetKeyDown("space"))
                    {
                        wallJump = true;
                        jumpPower = 0.0f;
                    }

                    if (wallJump == true && jumpPower < 1.5f)
                    {
                        Debug.Log("Wall Jump");
                        jumpPower += 0.05f;
                        transform.position = new Vector2(transform.position.x, transform.position.y + jumpPower);
                    }
                }

                //KEYPRESSES
                moveCharacter();

                if ((velocity > -changeSpeed || velocity < changeSpeed) && grounded == true)
                {
                    maxJump = 0.5f;
                }

                //JUMP KEYPRESS
                if (Input.GetKeyDown("space") && doubleJump != 2)
                {
                    inAir = true;
                    grounded = false;
                    Debug.Log("DoubleCounter" + doubleJump);

                    doubleJump++;



                }

                if (doubleJump == 2)
                {
                    maxJump = 1.0f;
                }

                if (inAir == true && jumpPower < maxJump)
                {
                    

                    jumpPower += 0.05f;
                    transform.position = new Vector2(transform.position.x, transform.position.y + jumpPower);
                }

                transform.position = new Vector2(transform.position.x + velocity, transform.position.y);
            }
           
        }
    }

    public void GetInputText()
    {
        string name = GameObject.Find("UserText").GetComponent<UnityEngine.UI.Text>().text;

        fh.WriteString(name, highestPlatform.ToString());
        
        SceneManager.LoadScene(0);
    }

    public void moveCharacter()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {

            velocity += Input.GetAxis("Horizontal") * acc;

            if (Input.GetAxis("Horizontal") < 0 && velocity > 0)
            {

                velocity -= 0.1f;
                
            }

            if (Input.GetAxis("Horizontal") > 0 && velocity < 0)
            {

                velocity += 0.1f;
                
            }

            
        }
    }

    public void quitGame()
    {
        SceneManager.LoadScene(0);
    }

    public float getPlatformCounter()
    {
        return platformCounter;
    }


    public bool isPaused()
    {
        return paused;
    }
}