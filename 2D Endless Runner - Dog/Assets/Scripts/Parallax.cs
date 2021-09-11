using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float Speed;
    public float OffSet;

    private Vector2 StartPosition;
    private float newXPosition;


    void Start()
    {
        StartPosition = transform.position;
    }

    void Update()
    {
        newXPosition = Mathf.Repeat(Time.time * -Speed, OffSet);

        transform.position = StartPosition + Vector2.right * newXPosition;
    }
}
