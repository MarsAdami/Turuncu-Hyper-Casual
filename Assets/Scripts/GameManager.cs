using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject loseUI;
    public GameObject winUi;

    public int score;
    public Text loseScoreText,winScoreText;
    public Text InGameScoreText;

    void Start()
    {

    }

    public void LevelEnd()
    {
        loseUI.SetActive(true);
        loseScoreText.text = "Puan: " + score;
        InGameScoreText.gameObject.SetActive(false);
    }

    public void WinLevel()
    {
        winUi.SetActive(true);
        winScoreText.text = "Puan: " + score;
        InGameScoreText.gameObject.SetActive(false);
    }

    

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void AddScore(int pointValue)
    {
        score += pointValue;
        InGameScoreText.text = "Puan: " + score;
    }

    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}

