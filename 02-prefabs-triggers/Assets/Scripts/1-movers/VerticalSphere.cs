using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component is represent the vertical spherical game world
 */
public class VerticalSphere : MonoBehaviour
{
    //the player object
    GameObject player;
    //width of the object
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        //initialize player object
        player = GameObject.FindGameObjectWithTag("Player");

        //get the height of the object
        objectHeight = player.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
       
            Vector3 pos = player.transform.position;
            //if the player is in the upest of the screen move it to the downest
            if (pos.y > 0)
            {
                player.transform.position = new Vector3(pos.x, -1 * pos.y+ objectHeight, pos.z);
            }
            //if the player is in the downest of the screen move it to the upest
            else
            {
                player.transform.position = new Vector3(pos.x, -1 * pos.y - objectHeight, pos.z);
            }
            
        }

    }
}
