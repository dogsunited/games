using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectIems : MonoBehaviour
{
    public int Shields;
    public Text AmountText;

    void Start()
    {
        Shields = PlayerPrefs.GetInt("Shields");
        AmountText.text = Shields.ToString();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gold"))
        {
            Shields ++;
            GetComponent<AudioSource>().Play();

            AmountText.text = Shields.ToString();
            PlayerPrefs.SetInt("Shields", Shields) ;

            Destroy(other.gameObject);
        }
    }
}
