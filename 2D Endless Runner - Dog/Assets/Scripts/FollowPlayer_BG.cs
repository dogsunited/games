using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer_BG : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        Vector2 TargetX = new Vector2(Target.position.x, transform.position.y);

        transform.position = TargetX;
    }
}
