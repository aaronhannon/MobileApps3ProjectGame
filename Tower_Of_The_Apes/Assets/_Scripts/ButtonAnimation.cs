using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{

    bool switchPos = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchPos == false)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z );
           // Debug.Log(transform.position.x);
            if (transform.position.x >= -29f )
            {
                switchPos = true;
            }
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            //Debug.Log(transform.position.x);
            if (transform.position.x <= -30f)
            {
                switchPos = false;
            }
        }
        


    }
}
