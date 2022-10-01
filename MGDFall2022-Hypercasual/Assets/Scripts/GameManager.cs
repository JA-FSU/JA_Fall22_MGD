using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button pauseButton;
    public Button startButton;
    public Button quitButton;
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
    private Spawner spawnManagerScript;
    private GameObject Player;

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
        quitButton.onClick.AddListener(CloseGame);
        startButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best: " + highScore;
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<Spawner>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameActive)
        {
            UpdateScore(Time.deltaTime);
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
        if (health <= 0)
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
            quitButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            return;
        }

        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            pauseText.SetActive(false);
            quitButton.gameObject.SetActive(false);
            Debug.Log("Game unpaused.");
            return;
        }
    }

    void StartGame()
    {
        Time.timeScale = 1.0f;
        health = 5;
        score = 0;
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        healthText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(false);
        scoreText.text = "" + score;
        healthText.text = "" + health;

        // Reset Player position
        Vector3 playerPos = Player.transform.position;
        playerPos.x = 0.0f;
        Player.transform.position = playerPos;

        //Destroy all spawned objects
        foreach (Transform child in spawnManagerScript.spawnManager.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        isGameActive = true;
    }

    void GameOver()
    {
        isGameActive = false;
        isPaused = false;
        pauseButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)Mathf.Round(score));
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        highScoreText.text = "Best: " + highScore;
        Time.timeScale = 0.0f;
    }

    void CloseGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    static void Quit()
    {
        Debug.Log("Quitting the Player");
    }

    [RuntimeInitializeOnLoadMethod]
    static void RunOnStart()
    {
        Application.quitting += Quit;
    }
}
