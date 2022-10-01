using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float score = 0.0f;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGameActive == true)
        {
            score += Time.deltaTime;
            scoreText.text = "" + Mathf.Round(score);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
