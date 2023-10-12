using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject highScoreText;
    public IntVariable gameScore;

    void Start()
    {
        SetHighScore();
    }

    public void GoToLoadScene()
    {
        gameScore.Value = 0;
        // once done, go to next scene
        SceneManager.LoadSceneAsync("LoadingScene", LoadSceneMode.Single);
    }

    void SetHighScore()
    {
        highScoreText.GetComponent<TextMeshProUGUI>().text = "High Score: " + gameScore.previousHighestValue.ToString("D6");
    }

    public void ResetHighScore()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        gameScore.ResetHighestValue();
        SetHighScore();
    }
}
