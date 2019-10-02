using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // use later for other stuff
    // add the collider stuff, to detect if a bullet hits
    // detect the collisiion
    // destroy the bullet prefab, then this prefab
    private int scoreValue = 10;

    // trigger event
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.GetComponent<Bullet>();
        var player = collision.GetComponent<PlayerMovement>();
        if(player)
        {
            // play a clip to inidcate a hit
            //Destroy(bullet);
            Destroy(gameObject);
        }
    }

}
