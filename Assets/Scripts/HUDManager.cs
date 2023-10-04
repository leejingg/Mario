using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextFinal;
    public GameObject gameOverUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
