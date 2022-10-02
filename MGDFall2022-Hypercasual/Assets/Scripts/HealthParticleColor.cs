using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticleColor : MonoBehaviour
{
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.startColor = new Color(95, 45, 100, 30);
    }
}
