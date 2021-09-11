using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_3 : MonoBehaviour
{
    public GameObject Lock;

    void Start()
    {
        if (PlayerPrefs.GetInt("Character3_UnlockPercentage") != 0)
        {
            Lock.SetActive(false);
        }
    }
}
