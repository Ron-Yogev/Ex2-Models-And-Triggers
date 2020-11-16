using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesLost : MonoBehaviour
{
    [SerializeField] GameObject gameover;
    private float lifes = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && this.enabled)
        {
            if (lifes == 0)
            {
                GameObject newObject = Instantiate(gameover.gameObject, new Vector3(1.5f, 0, 0), Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Life1"));
                Destroy(this.gameObject);
                Destroy(other.gameObject);

            }
            else
            {
                GameObject life = GameObject.FindGameObjectWithTag("Life" + (lifes+1f));
                Destroy(life.gameObject);
                lifes--;
            }
        }
    }
}
