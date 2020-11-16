using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component represt the frog movement in our game, 
 * NOTE: up and down with fixed steps, right and left with fixed speed
 */
public class KeyBoardFrogMover : MonoBehaviour
{
    [Tooltip("The number of steps each click up and down does")]
    [SerializeField] float upDownSteps = 3f;
    [Tooltip("The speed of the frog right and left click")]
    [SerializeField] float LeftRightSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        //moving the frog due to the arrows keys
        if (Input.GetKey("right"))
        {
            transform.position += new Vector3(Time.deltaTime * LeftRightSpeed, 0, 0);
        }
        else if (Input.GetKey("left"))
        {
            transform.position -= new Vector3(Time.deltaTime * LeftRightSpeed, 0, 0);
        }
        else if (Input.GetKeyDown("up"))
        {
            transform.position += new Vector3(0, upDownSteps, 0);
        }
        else if (Input.GetKeyDown("down"))
        {
            transform.position -= new Vector3(0, upDownSteps, 0);
        }
    }
}
