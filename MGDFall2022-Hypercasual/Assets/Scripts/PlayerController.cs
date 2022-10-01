using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            if (touchPos.y <= 1700)
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

        }
    }
}
