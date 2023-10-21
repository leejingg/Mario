using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextFinal;
    public GameObject gameOverUI;
    public GameObject highscoreText;
    public IntVariable gameScore;

    public void GameStart()
    {
        // hide gameover panel
        gameOverUI.SetActive(false);
    }

    public void SetScore()
    {
        scoreText.text = "Score: " + gameScore.Value.ToString();
    }


    public void GameOver()
    {
        // show gameover scene
        gameOverUI.SetActive(true);
        scoreTextFinal.text = scoreText.text;
        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }

    public void ReturnToMain()
    {
        Debug.Log("Return to main menu");
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
