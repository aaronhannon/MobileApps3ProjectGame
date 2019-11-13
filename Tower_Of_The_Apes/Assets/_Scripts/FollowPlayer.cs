﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    private float playerX;
    private float playerY;
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MainMenu");
        menu.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;



        transform.position = new Vector3(playerX, playerY, -22.0f);
    }
}
