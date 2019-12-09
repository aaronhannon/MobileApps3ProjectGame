using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCard : MonoBehaviour
{
    private bool rotateLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -40)
        {
            transform.position = new Vector3(transform.position.x + 1.5f * 3,transform.position.y,transform.position.z);
        }
        else
        {
            //Debug.Log(transform.rotation.y);

           // if (transform.rotation.y <= 0 && rotateLeft == true)
           // {
                transform.Rotate(new Vector3(0, transform.rotation.z + 0.5f, 0), Space.World);

        }
    }
}
