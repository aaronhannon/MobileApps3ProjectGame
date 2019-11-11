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
    private float timeLeft2 = 2.0f;
    private float platformCounter;
  


    private bool firstTimer = false;

    // Start is called before the first frame update
    void Start()
    {

        platGen = GetComponent<PlatformGenerator>();
        player = GameObject.Find("Player");
        platParent = GameObject.Find("PlatformContainer");
        platformCounter = platGen.getMaxPlatforms();
    }

    // Update is called once per frame
    void Update()
    {


        timeLeft1 -= Time.deltaTime;
        //Debug.Log("Time Left: " + timeLeft1);
        if (timeLeft1 < 0)
        {
            //Debug.Log("FIRST TIMERS UP");
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
                //Debug.Log("Time Left: " + timeLeft2);
                if (timeLeft2 < 0 && platformCounter !=0)
                {
                    //Debug.Log("TIMERS UP");
                    Destroy(platParent.transform.GetChild(0).gameObject);
                    timeLeft2 = 2.0f;
                    platformCounter--;
                }
            }



            //if (player.transform.position.y - 10 > platParent.transform.GetChild(0).gameObject.transform.position.y)
            //{
            //    Destroy(platParent.transform.GetChild(0).gameObject);
            //    Debug.Log("Destroyed");

            //}


            //done = true;
        }
        //        Debug.Log(player.transform.position.x);
    }

}
