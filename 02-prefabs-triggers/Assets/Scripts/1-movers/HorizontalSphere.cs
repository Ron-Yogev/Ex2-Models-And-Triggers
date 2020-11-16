using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is represent the horizontal spherical game world
 */
public class HorizontalSphere : MonoBehaviour
{
    //the player object
    GameObject player;
    //width of the object
    private float objectWidth;

    // Use this for initialization
    void Start()
    {
        //initialize player object
        player = GameObject.FindGameObjectWithTag("Player");

        //get the weight of the object
        objectWidth = player.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            Vector3 pos = player.transform.position;
            //if the player is in the left side of the screen move it to the left
            if (pos.x > 0)
            {
                player.transform.position = new Vector3(-1* pos.x +objectWidth, pos.y , pos.z);
            }
            else
            {
                player.transform.position = new Vector3(-1* pos.x - objectWidth, pos.y , pos.z);
            }

        }

    }
}
