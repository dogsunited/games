using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoresTable : MonoBehaviour
{
    public static HighscoresTable instance;
    private Transform entryContainer;
    private Transform entryTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTranformList;
    private Transform transformEntry;


    private void Awake()
    {
        instance = this;


        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTable");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscoreEntryTranformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntryl in highscores.highscoreEntryList)
        {
            if (highscores.highscoreEntryList.Count <= 10 && highscoreEntryl.score > 0)
            {
                CreateHighscoreEntryTable(highscoreEntryl, entryContainer, highscoreEntryTranformList);
            }
        }
    }

    private void Update()
    {       

    }

    public void CreateHighscoreEntryTable(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {

        Transform entryTransform = Instantiate(entryTemplate, container);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + ""; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.username;

        entryTransform.Find("userText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    
    public static void AddHighscoreEntry(string name, int score)
    {
        //Add a new highscore
        HighscoreEntry highscoreEntry = new HighscoreEntry { username = name, score = score };

        //load data you saved
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        highscores.highscoreEntryList.Add(highscoreEntry);
        highscores.highscoreEntryList.Sort((x, y) => x.score.CompareTo(y.score));
        highscores.highscoreEntryList = highscores.highscoreEntryList.GetRange(0, 9);

        //Save date
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    public class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    public class HighscoreEntry
    {
        public string username;
        public int score;

    }
}
