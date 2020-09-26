using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text highscoreText;

    private void Start()
    {
        if(PlayerPrefs.GetString("HighScoreName") != "")
        {
            highscoreText.text = "High Score" + "\t" + PlayerPrefs.GetString("HighScoreName") + "\t" + PlayerPrefs.GetInt("HighScore");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
