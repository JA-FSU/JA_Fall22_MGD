using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    private GameManager gameManager;
    public float speed = 40.0f;
    public float startSpeed;
    public float benchmarkScore = 100.0f;
    public bool speedRaisedMax;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        speedRaisedMax = false;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (gameManager.score >= benchmarkScore && !speedRaisedMax)
        {
            speed += 5.0f;
            benchmarkScore += 100.0f;
            if (speed >= startSpeed * 2.0f)
            {
                speedRaisedMax = true;
            }
        }
    }
}
