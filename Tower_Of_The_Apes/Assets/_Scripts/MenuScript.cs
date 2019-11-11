using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private GameObject camera;
    private bool buttonClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (buttonClicked == true)
        {
            if (camera.transform.rotation.y < 0)
            {
                camera.transform.Rotate(new Vector3(0, camera.transform.rotation.y + 1.5f, 0), Space.World);
            }
            else
            {
                buttonClicked = false;
            }
        }

    }

    public void play()
    {
        //while(camera.transform.rotation.y < 0)
        //{
        //    camera.transform.Rotate(new Vector3(0, camera.transform.rotation.y + 1.5f, 0), Space.World);
        //}

        buttonClicked = true;
    }
}
