using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSystem : MonoBehaviour
{
    public Light theSunMoon;
    public float cycleSpeed = 600.0f;
    public float cycleCounter = 0.0f;

    void Start()
    {
        theSunMoon = GetComponent<Light>();
    }

    void Update()
    {
        cycleSpeed -= Time.deltaTime;
        cycleCounter +=Time.deltaTime;
        if (cycleCounter >= 0.9375f){
            theSunMoon.intensity = theSunMoon.intensity - 0.0015625f;
            cycleCounter = 0.0f;
        }

        if (cycleSpeed >= 600.0f){
            cycleSpeed -= Time.deltaTime;
        } 
           
    }
}
