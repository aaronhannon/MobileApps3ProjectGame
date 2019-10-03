using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    private GameObject player;
    private GameObject floor;
    private PlatformGenerator platGen;
    private bool platCreated = false;
    private float platformSpeed = 0.01f;
    private int moveDirection;
    private float platformCounter;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        platformCounter = player.GetComponent<Move>().getPlatformCounter();

        switch (platformCounter)
        {
            case 0:
                platformSpeed = 0.00f;
                break;

            case 3:
                platformSpeed = 0.01f;
                break;

            case 5:
                platformSpeed = .05f;
                break;

            default:
                break;
        }


        if (!platCreated)
        {
            floor = GameObject.Find("Floor");
            platGen = floor.GetComponent<PlatformGenerator>();
            platCreated = platGen.getPlatformsDone();
            moveDirection = Random.RandomRange(0, 2);
           // Debug.Log(moveDirection);
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
