using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDecay : MonoBehaviour
{
    private PlatformGenerator platGen;
    private List<Platform> platList;
    bool done = false;
    bool platsCreated = false;
    GameObject platParent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        platGen = GetComponent<PlatformGenerator>();
        player = GameObject.Find("Player");
        platParent = GameObject.Find("PlatformContainer");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!platsCreated)
        {
            platsCreated = platGen.getPlatformsDone();

        }


        if (platsCreated && !done)
        {

            if(player.transform.position.y - 10 > platParent.transform.GetChild(0).gameObject.transform.position.y)
            {
                Destroy(platParent.transform.GetChild(0).gameObject);
                Debug.Log("Destroyed");

            }


            //done = true;
        }
//        Debug.Log(player.transform.position.x);
    }

}
