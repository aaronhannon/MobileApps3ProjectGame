﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private GameObject camera;
    private AudioSource audioData;
    private bool playClicked = false;
    private bool optionClicked = false;
    private bool backClicked = false;
    private bool scoresClicked = false;
    private bool backScoreClicked = false;
    private bool guideClicked = false;
    private bool backGuideClicked = false;
  

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        audioData = GetComponent<AudioSource>();

    }

    void Update()
    {

        if (playClicked == true)
        {
            
            if (camera.transform.rotation.y < 0)
            {
                camera.transform.Rotate(new Vector3(0, camera.transform.rotation.y + 1.5f, 0), Space.World);
                
            }
            else
            {
                playClicked = false;
                 
                
            }
        }

        if(backClicked == true)
        {
            Debug.Log("Back Camera Y: " + camera.transform.localRotation.y);

            if (camera.transform.rotation.y <= -0.7)
            {
                Debug.Log("Back Clicked");
                camera.transform.Rotate(new Vector3(0, camera.transform.rotation.y + 2.0f, 0), Space.World);
            }
            else
            {
                backClicked = false;
            }

        }
        
        if(optionClicked == true)
        {

            Debug.Log("Options Camera Y: " + camera.transform.rotation.y);

            if (camera.transform.rotation.y > -0.9999)
            {
                camera.transform.Rotate(new Vector3(0, camera.transform.rotation.y - 1.5f, 0), Space.World);
            }
            else
            {
                Debug.Log("STOP");
                optionClicked = false;
            }
            //camera.transform.eulerAngles = Vector3.Lerp(camera.transform.eulerAngles, new Vector3(0, 180, 0), Time.deltaTime * 1.5f);
        }

        if (scoresClicked == true)
        {
            

            if (camera.transform.rotation.z > -0.5)
            {
                camera.transform.Rotate(new Vector3(0, 0, camera.transform.rotation.y - 2.0f), Space.World);
            }
            else
            {
                
                scoresClicked = false;
            }
        }

        if (backScoreClicked == true)
        {
            

            if (camera.transform.rotation.z <= -0.009f)
            {
                
                camera.transform.Rotate(new Vector3(0, 0, camera.transform.rotation.y + 2.0f), Space.World);
            }
            else
            {
                backScoreClicked = false;
            }

        }

        if(guideClicked == true)
        {
            if (camera.transform.rotation.z < 0.5)
            {
                camera.transform.Rotate(new Vector3(0, 0, camera.transform.rotation.y + 2.0f), Space.World);
            }
            else
            {

                guideClicked = false;
            }
        }

        if (backGuideClicked == true)
        {


            if (camera.transform.rotation.z >= 0.009f)
            {

                camera.transform.Rotate(new Vector3(0, 0, camera.transform.rotation.y - 2.0f), Space.World);
            }
            else
            {
                backGuideClicked = false;
            }

        }

    }

    public void play()
    {
        playClicked = true;
    }

    public void options()
    {
        optionClicked = true;
    }

    public void back()
    {
        optionClicked = false;
        backClicked = true;
        
    }

    public void backScores()
    {
        scoresClicked = false;
        backScoreClicked = true;

    }

    public void backGuide()
    {
        guideClicked = false;
        backGuideClicked = true;

    }

    public void guide()
    {
        guideClicked = true;
    }

    public void scores()
    {
        scoresClicked = true;
    }

}
