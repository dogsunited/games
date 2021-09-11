using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UnlockDetector : MonoBehaviour
{
    public int Price;

    private int Character2_UnlockPercentage = 0;
    private int Character3_UnlockPercentage = 0;
    private int Character4_UnlockPercentage = 0;

    void Start()
    {
        Character2_UnlockPercentage = PlayerPrefs.GetInt("Character2_UnlockPercentage");
        Character3_UnlockPercentage = PlayerPrefs.GetInt("Character3_UnlockPercentage");
        Character4_UnlockPercentage = PlayerPrefs.GetInt("Character4_UnlockPercentage");
    }

    void Update()
    {
        
    }

    public void Character2()
    {
        if(Character2_UnlockPercentage != 100)
        {
            if (PlayerPrefs.GetInt("Shields") >= Price)
            {
                int val2 = PlayerPrefs.GetInt("Shields");

                val2 -= Price;

                PlayerPrefs.SetInt("Shields", val2);

                Character2_UnlockPercentage = 100;
                PlayerPrefs.SetInt("Character2_UnlockPercentage", Character2_UnlockPercentage);


                SceneManager.LoadScene("Character2");
            }
        }
        else if(Character2_UnlockPercentage == 100)
        {
            SceneManager.LoadScene("Character2");
        }
        
    }

    public void Character3()
    {
        if (PlayerPrefs.GetInt("Shields") >= Price)
        {
            int val3= PlayerPrefs.GetInt("Shields");

            val3 -= Price;

            PlayerPrefs.SetInt("Shields", val3);

            Character3_UnlockPercentage = 100;
            PlayerPrefs.SetInt("Character3_UnlockPercentage", Character3_UnlockPercentage);


            SceneManager.LoadScene("Character3");
        }
    
        else if(Character3_UnlockPercentage == 100)
        {
            SceneManager.LoadScene("Character3");
        }
    }

    public void Character4()
    {
         if (PlayerPrefs.GetInt("Shields") >= Price)
         {
                int val4 = PlayerPrefs.GetInt("Shields");

                val4 -= Price;

                PlayerPrefs.SetInt("Shields", val4);

                Character4_UnlockPercentage = 100;
                PlayerPrefs.SetInt("Character4_UnlockPercentage", Character4_UnlockPercentage);


                SceneManager.LoadScene("Character4");
         }
        
        else if(Character4_UnlockPercentage == 100)
        {
            SceneManager.LoadScene("Character4");
        }
    }
}
