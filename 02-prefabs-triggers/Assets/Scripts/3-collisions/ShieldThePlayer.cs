using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component should preform a shield on the player after he takes it from around the screen
 */
public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other) {
        //after the player takes the shield
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            GameObject shield = GameObject.FindGameObjectWithTag("Shield");
            // destroy the shield icon
            Destroy(shield.gameObject);
            //preform the shield that protects the player
            GameObject temp_shield = GameObject.FindGameObjectWithTag("temp_shield");
            Color tmp = temp_shield.GetComponent<MeshRenderer>().material.color;
            temp_shield.GetComponent<MeshRenderer>().material.color = new Color(tmp.r, tmp.g, tmp.b, 150f/256f);

            //disabling the component that "kill" the player for duration secaonds
            var destroyComponent = other.GetComponent<LifesLost>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent, temp_shield, shield));
            }
        } 
        else {
            Debug.Log("Shield triggered by "+other.name);
        }
       
   
    }

    private IEnumerator ShieldTemporarily(LifesLost destroyComponent, GameObject temp_shield, GameObject shield) {
        MeshRenderer other = temp_shield.GetComponent<MeshRenderer>();
        //presenting a yellow shield protector around the player
        Color origcolor = other.material.color- new Color(0, 0, 0, 150f/256f);
        //disabling the component that "kill" the player for duration secaonds
        destroyComponent.enabled = false;
        //we want the shield will dissapear in jump steps 
        float jump = 150f / (duration * 5f * 256f);
        for (float i = duration * duration; i > 0; i--) {
            Debug.Log("Shield: " + i/ duration + " seconds remaining!");
            Color rgba = other.material.color;
            other.material.color -= new Color(0, 0,0, jump);
            yield return new WaitForSeconds(1/duration);
        }
        Debug.Log("Shield gone!");

        // keeping the player hitable
        other.material.color = origcolor;
        destroyComponent.enabled = true;
    }
}
