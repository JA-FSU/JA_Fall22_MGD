using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button pauseButton;
    public Button startButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI highScoreText;
    public GameObject pauseText;
    public float score = 0.0f;
    public int health = 5;
    public int highScore = 0;
    public bool isGameActive;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        isPaused = false;
        score = 0;
        pauseText.SetActive(false);
        scoreText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        pauseButton.onClick.AddListener(PauseGame);
        startButton.onClick.AddListener(StartGame);
        startButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: " + highScore;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameActive)
        {
            UpdateScore(Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdateScore(float scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "" + Mathf.Round(score);
    }

    public void UpdateHealth(int HealthToSubtract)
    {
        health -= HealthToSubtract;
        if (health < 0)
        {
            health = 0;
            GameOver();
        }
        healthText.text = "" + health;
    }

    void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Debug.Log("Game paused.");
            pauseText.SetActive(true);
            Time.timeScale = 0.0f;
            return;
        }

        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            pauseText.SetActive(false);
            Debug.Log("Game unpaused.");
            return;
        }
    }

    void StartGame()
    {
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(false);
        scoreText.text = "" + health;
        isGameActive = true;
    }

    void GameOver()
    {
        isGameActive = false;
        isPaused = false;
        healthText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(true);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)Mathf.Round(score));
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        scoreText.gameObject.SetActive(false);
        highScoreText.text = "Best: " + highScore;
    }
}
