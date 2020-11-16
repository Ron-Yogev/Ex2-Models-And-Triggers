using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component should low your lifes in the game
 */
public class LifesLost : MonoBehaviour
{
    [Tooltip("prefab we mesh text of gameover")]
    [SerializeField] GameObject gameover;
    //he got 3 lifes(if we count from 0 its 2)
    private float lifes = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the enemy hit the player and he dont have shield
        if (other.tag == "Enemy" && this.enabled)
        {
            //no lifes left
            if (lifes == 0)
            {
                GameObject newObject = Instantiate(gameover.gameObject, new Vector3(1.5f, 0, 0), Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Life1"));
                Destroy(this.gameObject);
                Destroy(other.gameObject);

            }
            //theres lifes left
            else
            {
                //sets the current life to down
                GameObject life = GameObject.FindGameObjectWithTag("Life" + (lifes+1f));
                Destroy(life.gameObject);
                lifes--;
            }
        }
    }
}
