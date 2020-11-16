using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys a gameobject after a duration secaonds
 */
public class DestroySpawner : MonoBehaviour
{
    [Tooltip("The secaonds the object will last till he will destroy")]
    [SerializeField] float duration = 5f;

    // Start is called before the first frame update
    void Start()
    {

        this.StartCoroutine(DeleteTime());
    }

    private IEnumerator DeleteTime()
    {   
        // wait duration seaconds and destroy the object 
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
        
    }
}
