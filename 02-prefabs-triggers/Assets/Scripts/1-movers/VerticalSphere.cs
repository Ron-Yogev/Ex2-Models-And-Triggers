using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSphere : MonoBehaviour
{
    GameObject player;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //get the height of the object
        objectHeight = player.transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
       
            Vector3 pos = player.transform.position;
            if (pos.y > 0)
            {
                player.transform.position = new Vector3(pos.x, -1 * pos.y+ objectHeight, pos.z);
            }
            else
            {
                player.transform.position = new Vector3(pos.x, -1 * pos.y - objectHeight, pos.z);
            }
            
        }

    }
}
