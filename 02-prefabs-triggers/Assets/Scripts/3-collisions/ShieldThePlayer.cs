using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");

            GameObject shield = GameObject.FindGameObjectWithTag("temp_shield");
            Color tmp = shield.GetComponent<MeshRenderer>().material.color;
            shield.GetComponent<MeshRenderer>().material.color = new Color(tmp.r, tmp.g, tmp.b, 150f/256f);
            Debug.Log("tmp:" + tmp);
            Debug.Log("shield:" + shield.GetComponent<MeshRenderer>().material.color);
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent,shield));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                //Destroy(gameObject);  // Destroy the shield itself - prevent double-use
                //this.enabled = false;


            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
       
   
    }

    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent, GameObject shield) {
        MeshRenderer other = shield.GetComponent<MeshRenderer>();
        Color origcolor = other.material.color- new Color(0, 0, 0, 150f/256f); ;
        destroyComponent.enabled = false;
        float jump = 150f / (duration * 5f * 256f);
        for (float i = duration * 5; i > 0; i--) {
            Debug.Log("Shield: " + i/5 + " seconds remaining!");
            Color rgba = other.material.color;
            other.material.color -= new Color(0, 0,0, jump);
            Debug.Log("tmp:" + other.material.color);
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("Shield gone!");

        other.material.color = origcolor;
        destroyComponent.enabled = true;
    }
}
