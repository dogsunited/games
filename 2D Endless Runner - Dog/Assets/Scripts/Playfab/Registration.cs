using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;

    string Url = "http://localhost/sqlconnect/nameregistration.php";
    public Button submitButton;

    
    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", nameField.text);
        WWW www = new WWW(Url, form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("user created successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else 
        {
            Debug.Log("user creation failed. Error #" + www.text);
        }
    }
    public void VerifyInput()
    {
        submitButton.interactable = (nameField.text.Length >= 8);
    }
}
