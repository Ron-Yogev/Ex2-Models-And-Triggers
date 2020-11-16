using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawner : MonoBehaviour
{
    [SerializeField] float duration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        this.StartCoroutine(DeleteTime());
    }

    private IEnumerator DeleteTime()
    {   
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
        
    }
}
