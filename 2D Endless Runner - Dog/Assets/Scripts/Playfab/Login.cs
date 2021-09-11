using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public Text loginInfo;

    string Url = "http://localhost/sqlconnect/namelogin.php";
    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {

        WWWForm form = new WWWForm();
        form.AddField("usernamePost", nameField.text);
        WWW www = new WWW(Url, form);
        yield return www;
        if (www.text[0] == '0')
        {
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            HighscoresTable.AddHighscoreEntry(DBManager.username, DBManager.score);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            loginInfo.text = "This name doesn't exist.";
            Debug.Log("User login failed. Error #" + www.text);
        }
    }
    public void VerifyInput()
    {
        submitButton.interactable = (nameField.text.Length >= 8);
    }
}
