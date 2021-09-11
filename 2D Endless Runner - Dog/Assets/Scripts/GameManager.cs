using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Default()
    {
        SceneManager.LoadScene("Default");
    }
    public void LeaderBoard()
    {

        SceneManager.LoadScene("LeaderBoard");
    } 
    
    public void LeaderDisplay()
    {

        SceneManager.LoadScene("LeaderDisplay");
    }

}
