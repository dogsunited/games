using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Saw : MonoBehaviour
{
    public float RotateSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, 0f, RotateSpeed);
    }
}
