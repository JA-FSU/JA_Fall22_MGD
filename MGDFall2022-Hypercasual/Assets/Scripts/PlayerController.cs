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
        if (Input.touchCount > 0 && gameManager.isGameActive && !gameManager.isPaused)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            if (touchPos.y <= Screen.height / 2 && touch.phase == TouchPhase.Began)
            {
                if (touchPos.x <= Screen.width / 2 && transform.position.x > -4)
                {
                    Vector3 pos = transform.position;
                    pos.x -= 4.0f;
                    transform.position = pos;
                    return;
                }
                else if (touchPos.x >= Screen.width / 2 && transform.position.x < 4)
                {
                    Vector3 pos = transform.position;
                    pos.x += 4.0f;
                    transform.position = pos;
                    return;
                }
            }
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

        if (other.gameObject.CompareTag("Pancakes"))
        {
            audioSource.PlayOneShot(SE[2]);
        }
    }
}
