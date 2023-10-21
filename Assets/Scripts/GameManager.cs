using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // events
    public UnityEvent gameStart;
    public UnityEvent<int> scoreChange;
    public IntVariable gameScore;
    private AudioSource audioSource;

    void Start()
    {
        gameStart.Invoke();
    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        // subscribe to scene manager scene change
        SceneManager.activeSceneChanged += SceneSetup;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void SceneSetup(Scene current, Scene next)
    {
        gameStart.Invoke();
        SetScore(gameScore.Value);
        if (next.name == "World-1-1" || current.name == "World-1-1")
        {
            gameScore.Value = 0;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameRestart()
    {
        // reset score
        gameScore.Value = 0;
        SetScore(0);
        Time.timeScale = 1.0f;
        audioSource.Stop();
        audioSource.Play();
    }

    public void IncreaseScore(int increment)
    {
        // increase score
        gameScore.ApplyChange(increment);
        SetScore(gameScore.Value);
    }

    public void SetScore(int score)
    {
        // invoke score change event with current score to update HUD
        scoreChange.Invoke(score);
    }


    public void GameOver()
    {
        Time.timeScale = 0.0f;
        audioSource.Stop();
    }
}