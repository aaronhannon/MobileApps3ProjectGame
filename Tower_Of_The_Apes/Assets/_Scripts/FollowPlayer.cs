using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public float cameraZoom = -28.0f;
    private float playerX;
    private float playerY;
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MainMenu");
        menu.active = false;
    }

    //Sets the players X and Y to the Cameras so that the camera follows the player.
    void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;


        transform.position = new Vector3(playerX, playerY, cameraZoom);
    }
}
