using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.transform.position.x < transform.position.x)
        {
            player.transform.position = new Vector2(player.transform.position.x + transform.localScale.y / 2, player.transform.position.y);
        }

    }
}
