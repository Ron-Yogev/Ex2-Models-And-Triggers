using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLost : MonoBehaviour
{
    [SerializeField] GameObject WinText;
    [SerializeField] GameObject GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WinLine")
        {
            GameObject newObject = Instantiate(WinText.gameObject, new Vector3(1.5f,0,0), Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(other.tag == "Car")
        {
            GameObject newObject = Instantiate(GameOverText.gameObject, new Vector3(1.5f, 0, 0), Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
