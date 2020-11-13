using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFor5Sec : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield")
        {
            var destroyComponent = this.GetComponent<DestroyOnTrigger2D>();
            if (destroyComponent)
            {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));
                // NOTE: If you just call "StartCoroutine", then it will not work, 
                //       since the present object is destroyed!
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        }
        else
        {
            Debug.Log("Shield triggered by " + other.name);
        }
    }


    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent)
    {
        destroyComponent.enabled = true;
        for (float i = 5; i > 0; i--)
        {
            Color rgba = this.GetComponent<MeshRenderer>().material.color;
            this.GetComponent<MeshRenderer>().material.color -= new Color(rgba.r, rgba.g, rgba.b, rgba.a - 0.08f);
            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Shield gone!");
        destroyComponent.enabled = false;
    }
}
