using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardFrogMover : MonoBehaviour
{
    Vector3 pos;
    [SerializeField] float upDownSteps = 3f;
    [SerializeField] float LeftRightSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
