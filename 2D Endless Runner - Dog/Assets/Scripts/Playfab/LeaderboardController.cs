using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class LeaderboardController : MonoBehaviour
{
    public static LeaderboardController instance;
    public GameObject listingPrefab;
    public Transform listingContainer;
    public int usernameIndex;
    #region Leaderboard
    private void Awake()
    {
        if (instance == null)
            instance = this;

        //listingContainer = transform.Find("entryContainer").GetComponent<Transform>();

    }
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "endless_leaderboard", Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnErrorLeaderboard);

    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {

        Debug.Log("Successful Leaderboard Sent");
    }
    public void GetLeadeboard()
    {
        if (listingContainer.childCount >= 10)
        {
            Destroy(listingContainer.GetChild(9).gameObject);
        }
        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "endless_leaderboard", MaxResultsCount = 10 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnErrorLeaderboard);

    }

    void OnGetLeaderboard(GetLeaderboardResult result)
    {
        foreach (var player in result.Leaderboard)
        {
            GameObject tempListing = Instantiate(listingPrefab, listingContainer);
            ScoreboardListing LL = tempListing.GetComponent<ScoreboardListing>();
            LL.playerNameText.text = player.DisplayName;
            LL.playerScoreText.text = player.StatValue.ToString();
            Debug.Log(player.Position + " - " + player.PlayFabId + ": " + player.StatValue);
        }
    }
    public void CloseLeaderboard()
    {

        for (int i = 0; i < listingContainer.childCount; i++)
        {
            Destroy(listingContainer.GetChild(i).gameObject);
        }
    }
    void OnErrorLeaderboard(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    #endregion Leaderboard
}
