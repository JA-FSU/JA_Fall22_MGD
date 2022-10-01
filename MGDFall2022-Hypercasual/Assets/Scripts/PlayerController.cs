using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            Debug.Log(Input.touchCount);
            Debug.Log(touchPos);
        }

        if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(1);
            Vector2 touchPos = touch.position;
            Debug.Log(Input.touchCount);
        }
    }
}
