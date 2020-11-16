using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component trigered when the enemy and the laser pass the camera, and destroy them
 */
public class DestroyOutOfScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the laser or the enemy gets to the borders destroy them
        if (other.tag == "Laser" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

    }
}
