using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.UI;
using TMPro;

public class GameManager:MonoBehaviour
{
    public static GameManager Instance;
    public bool gameStarted = false;
    public GameObject player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject spawner;


    int lives = 3;
    int score = 0;

    public void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gameUI.SetActive(true);
        spawner.SetActive(true);


    }

    public void GameOver()
    {
        player.SetActive(false);

        Invoke("ReloadLevel", 1.5f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLife()
    {

        if(lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
