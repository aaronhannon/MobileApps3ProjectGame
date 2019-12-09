using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField]
    private Platform plat;
    private List<Platform> platList;
    private int maxPlatforms = 100;
    private int platformCounter = 0;
    private GameObject platformParent;
    private bool platsCreated = false;


    // Start is called before the first frame update
    void Start()
    {
        platList = new List<Platform>();
        platformParent = GameObject.Find("PlatformContainer");
        if (!platformParent)
        {
            platformParent = new GameObject("PlatformContainer");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (platformCounter < maxPlatforms)
        {
            

            plat.transform.position = new Vector2(Random.Range(-7.0f, 7.0f), 2.0f+(platformCounter * 2f));
            plat.transform.localScale = new Vector2(Random.Range(1.0f, 2.0f), 1.0f);
            Instantiate<Platform>(plat,platformParent.transform);
            platList.Add(plat);
            platformCounter++;
            //Debug.Log(platformCounter);
            
            
            
        }
        else
        {
            platsCreated = true;
            
            
        }
    }

    public int getMaxPlatforms()
    {
        return maxPlatforms;
    }

    public List<Platform> GetPlatforms()
    {
        return platList;
    }

    public bool getPlatformsDone()
    {
        return platsCreated;
    }


    public GameObject getParentContainer()
    {
        return platformParent;
    }
}
