using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugGuy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Animator>().Play("Die");
        }
       
    }
}
