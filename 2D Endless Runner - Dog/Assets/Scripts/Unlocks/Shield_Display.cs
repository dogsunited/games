using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shield_Display : MonoBehaviour
{
    public Text Shield;

    void Start()
    {
        Shield.text = PlayerPrefs.GetInt("Shields").ToString();   
    }

}
