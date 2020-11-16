using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component showing win or lost text on the screen
 */
public class WinOrLost : MonoBehaviour
{
    [Tooltip("prefab mesh text of win")]
    [SerializeField] GameObject WinText;
    [Tooltip("prefab mesh text of gameover")]
    [SerializeField] GameObject GameOverText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the frog got to the winline
        if (other.tag == "WinLine")
        {
            GameObject newObject = Instantiate(WinText.gameObject, new Vector3(1.5f,0,0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        //if the frog hit from the car
        if (other.tag == "Car")
        {
            GameObject newObject = Instantiate(GameOverText.gameObject, new Vector3(1.5f, 0, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
