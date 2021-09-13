using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabController : MonoBehaviour
{
    public static PlayfabController instance;

    private static string displayName;
    private static string usernameID;
    public bool loggedIn;


    #region PlayerStats
    private void Awake()
    {
        if (instance == null)
            instance = this;
        loggedIn = false;
        Login();

    }

    public void GetUserUpdateName(string displayNameIn)
    {
        displayName = displayNameIn;
    }
    public void GetUsername(string usernameIn)
    {
        usernameID = usernameIn;
    }

    public void Login()
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier + Random.Range(1, 15).ToString(), CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);


    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations LOGIN call");
        loggedIn = true;
    }


    private void OnLoginFailure(PlayFabError error)
    {
        var registerRequest = new RegisterPlayFabUserRequest { Username = SystemInfo.deviceUniqueIdentifier };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
        loggedIn = false;
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your fisrt successful REGISTER call");
    }
    public void UpdateDisplayName()
    {
        if (displayName != null)
        {
            var request = new UpdateUserTitleDisplayNameRequest();
            request.DisplayName = displayName;
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnPlayerNameResult, OnRegisterFailure);
        }

    }
    public void OnPlayerNameResult(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Your account name updated successfully!");
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
    #endregion PlayerSats


}