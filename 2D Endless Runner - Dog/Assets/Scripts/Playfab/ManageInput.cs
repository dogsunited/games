using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManageInput : MonoBehaviour
{
    public static ManageInput instance;

    public InputField inputUsername;
    public Button loginButton;
    public Text textScore;
    private static float userScore;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {

        if (PlayfabController.instance.loggedIn)
        {
            if (LeaderboardController.instance.listingContainer.childCount > 0)
            {
                LeaderboardController.instance.CloseLeaderboard();
            }
            LeaderboardController.instance.GetLeadeboard();

        }

        textScore.text = PlayerMovement.distancemeters.ToString();
    }
    private void Update()
    {
        userScore = PlayerMovement.distancemeters;
        Debug.Log(userScore);


    }
    public void UsernameInput()
    {
        if (inputUsername.text != null)
        {
            LeaderboardController.instance.SendLeaderboard((int)userScore);
            PlayfabController.instance.GetUserUpdateName(inputUsername.text);
            PlayfabController.instance.UpdateDisplayName();
            StartCoroutine(ShowScore());
        }
    }
    IEnumerator ShowScore()
    {
        yield return new WaitForSeconds(1.5f);
        LeaderboardController.instance.CloseLeaderboard();
        LeaderboardController.instance.GetLeadeboard();
    }
    public void VerifyValue()
    {
        loginButton.interactable = (inputUsername.text.Length >= 2);
    }

    public void DisableLogins()
    {
        loginButton.gameObject.SetActive(false);
        inputUsername.gameObject.SetActive(false);
    }

}
