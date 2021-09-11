using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_2 : MonoBehaviour
{
    public GameObject Lock;

    void Start()
    {
        if( PlayerPrefs.GetInt("Character2_UnlockPercentage") != 0)
        {
            Lock.SetActive(false);
        }
    }

}
