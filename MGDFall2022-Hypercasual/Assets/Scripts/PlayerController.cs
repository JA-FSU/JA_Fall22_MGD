using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;
    public AudioClip[] SE;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            if (touchPos.y <= Screen.height / 2)
            {
                //if (touchPos.x)
                Debug.Log(Input.touchCount);
                Debug.Log(touchPos);
            }
        }

        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(1);
            Vector2 touchPos = touch.position;
            Debug.Log(Input.touchCount);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(SE[0]);
        }

        if (other.gameObject.CompareTag("Food") || other.gameObject.CompareTag("Pancakes"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(10.0f);
            audioSource.PlayOneShot(SE[1]);
        }

        if (other.gameObject.CompareTag("Food"))
        {
            return;
        }
    }
}
