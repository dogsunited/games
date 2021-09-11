using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCol : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
