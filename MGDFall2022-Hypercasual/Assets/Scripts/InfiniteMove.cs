using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMove : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float divide = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = transform.localScale.z / divide;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
