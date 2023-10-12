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

    void Awake()
    {
        // subscribe to events
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameOver.AddListener(GameOver);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);

    }

    public void GameStart()
    {
        // hide gameover panel
        gameOverUI.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
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
