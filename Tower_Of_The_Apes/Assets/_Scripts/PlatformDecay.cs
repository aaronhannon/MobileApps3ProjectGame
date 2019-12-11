using System.Collections.Generic;
using UnityEngine;

public class PlatformDecay : MonoBehaviour
{
    private PlatformGenerator platGen;
    private List<Platform> platList;
    bool platsCreated = false;
    GameObject platParent;
    GameObject player;
    private float timeLeft1 = 5.0f;
    private float timeLeft2 = 1.0f;
    private float platformCounter;
    private GameObject camera;
    private FollowPlayer follow;
    private bool paused = false;


    private bool firstTimer = false;

    // Start is called before the first frame update
    void Start()
    {

        platGen = GetComponent<PlatformGenerator>();
        player = GameObject.Find("Player");
        platParent = GameObject.Find("PlatformContainer");
        platformCounter = platGen.getMaxPlatforms();
        camera = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        //If you clicked the playbutton
        if(camera.transform.rotation.y > 0 && camera.transform.rotation.y < 0.1)
        {
            follow = camera.GetComponent<FollowPlayer>();
            follow.enabled = true;

            paused = player.GetComponent<Move>().isPaused();

            if (paused == false)
            {
                //TimeLeft1 is a large timer that lets the player have a head start
                timeLeft1 -= Time.deltaTime;
                
                //once that time is up the second timer gets activated and its a lot faster
                if (timeLeft1 < 0)
                {
                   
                    firstTimer = true;
                }


                if (!platsCreated)
                {
                    platsCreated = platGen.getPlatformsDone();

                }

                if (platsCreated)
                {

                    if (firstTimer)
                    {

                        timeLeft2 -= Time.deltaTime;
                        
                        //if the time is up the first child platform is removed from the container.
                        if (timeLeft2 < 0 && platformCounter != 0)
                        {
                            //Debug.Log("TIMERS UP");
                            Destroy(platParent.transform.GetChild(0).gameObject);
                            timeLeft2 = 1f;
                            platformCounter--;
                        }
                    }
                }
            }

        }
        
    }

}
