using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnerPrefabs;
    public float[] spawnLocations;
    private GameManager gameManager;
    public Transform spawnManager;
    private float startDelay = 2.0f;
    public float spawnInterval = 1.14f;
    public bool spawnStarted;

    //private void Awake()
    //{
        //StartCoroutine(SpawnRandom());
    //}

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<Transform>();

        spawnStarted = false;

        InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score > 500)
        {
            spawnInterval = 0.7f;
        }

        if (!gameManager.isGameActive || gameManager.isPaused)
        {
            spawnStarted = false;
        }
        else
        {
            spawnStarted = true;
        }
    }

    //IEnumerator
    void SpawnRandom()
    {
        //while (spawnStarted)
        //{
            //Debug.Log("Wait start.");
            //yield return new WaitForSeconds(spawnInterval);
            //Debug.Log("Wait is over.");
        if (gameManager.isGameActive && !gameManager.isPaused)
        {
            int spawnerIndex = Random.Range(0, spawnerPrefabs.Length);
            int random = Random.Range(0, spawnLocations.Length);
            float randomChoose = spawnLocations[random];
            Vector3 locationIndex = new Vector3(randomChoose, 2.53f, 300.0f);
            GameObject spawnable = Instantiate(spawnerPrefabs[spawnerIndex], locationIndex, spawnerPrefabs[spawnerIndex].transform.rotation);
            spawnable.transform.parent = spawnManager;
        }
        //}
    }
}
