using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnerPrefabs;
    public float[] spawnLocations;
    private GameManager gameManager;
    public Transform spawnManager;
    private float startDelay = 2;
    private float spawnInterval = 1.14f;

    //private IEnumerator spawnSystem;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<Transform>();
        InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
        // spawnSystem = SpawnRandom()''
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.score > 500)
        //{
            //spawnInterval = 0.8f;
            //InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
        //}
    }

    void SpawnRandom()
    {
        int spawnerIndex = Random.Range(0, spawnerPrefabs.Length);
        int random = Random.Range(0, spawnLocations.Length);
        float randomChoose = spawnLocations[random];
        Vector3 locationIndex = new Vector3(randomChoose, 2.53f, 300.0f);
        
        if (gameManager.isGameActive && !gameManager.isPaused)
        {
            GameObject spawnable = Instantiate(spawnerPrefabs[spawnerIndex], locationIndex, spawnerPrefabs[spawnerIndex].transform.rotation);
            spawnable.transform.parent = spawnManager;
        }
    }
}
