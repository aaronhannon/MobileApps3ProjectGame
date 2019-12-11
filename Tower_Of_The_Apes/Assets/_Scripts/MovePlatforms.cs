using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    private GameObject player;
    private GameObject floor;
    private PlatformGenerator platGen;
    private bool platCreated = false;
    private float platformSpeed = 0.00f;
    private int moveDirection;
    private float platformCounter;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        paused = player.GetComponent<Move>().isPaused();

        if (paused == false)
        {
            platformCounter = player.GetComponent<Move>().getPlatformCounter();

            if(platformCounter > 40)
            {
                platformSpeed = .15f;
            }
            else if (platformCounter > 20 && platformCounter < 40)
            {
                platformSpeed = 0.1f;
            }
            else if(platformCounter < 1)
            {
                platformSpeed = 0.01f;
            }


            if (!platCreated)
            {
                floor = GameObject.Find("Floor");
                platGen = floor.GetComponent<PlatformGenerator>();
                platCreated = platGen.getPlatformsDone();
                moveDirection = Random.RandomRange(0, 2);
                
            }


            if (platCreated)
            {
                if (moveDirection == 0)
                {
                    transform.position = new Vector2(transform.position.x - platformSpeed, transform.position.y);

                    if (transform.position.x - transform.localScale.x / 2 < -11)
                    {
                        moveDirection = 1;
                    }
                }
                else
                {
                    transform.position = new Vector2(transform.position.x + platformSpeed, transform.position.y);

                    if (transform.position.x + transform.localScale.x / 2 > 11)
                    {
                        moveDirection = 0;
                    }
                }
            }
        }


    }
}
