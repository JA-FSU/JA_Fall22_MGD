using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button pauseButton;
    public float score = 0.0f;
    public TextMeshProUGUI scoreText;
    public GameObject pauseText;
    public bool isGameActive;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        isPaused = false;
        score = 0;
        pauseText.SetActive(false);
        pauseButton.onClick.AddListener(PauseGame);
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
}
