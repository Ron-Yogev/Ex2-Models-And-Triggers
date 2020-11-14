using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSphere : MonoBehaviour
{
    GameObject player;
    private float objectWidth;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //get the weight of the object
        objectWidth = player.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            Vector3 pos = player.transform.position;
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
