using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistacneCalculator : MonoBehaviour
{
    public static DistacneCalculator ins;
    public static float meters;
    public Text metersText;

    public Transform player;
    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
        meters = 0;
       // PlayerPrefs.SetFloat("meters", meters);
    }

    void Update()
    {
        meters = Mathf.Floor((Vector3.Distance(player.transform.position, new Vector3(0, 5, -10)) / 5));
        metersText.text = meters.ToString();
        PlayerPrefs.SetFloat("meters", meters);
        PlayerPrefs.Save();
    }
}
