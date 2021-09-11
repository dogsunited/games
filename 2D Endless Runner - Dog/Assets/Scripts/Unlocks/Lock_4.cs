using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_4 : MonoBehaviour
{
    public GameObject Lock;

    void Start()
    {
        if (PlayerPrefs.GetInt("Character4_UnlockPercentage") != 0)
        {
            Lock.SetActive(false);
        }
    }
}
