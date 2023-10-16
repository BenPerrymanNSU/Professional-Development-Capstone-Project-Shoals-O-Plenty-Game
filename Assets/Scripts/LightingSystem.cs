using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSystem : MonoBehaviour
{
    public Light theSunMoon;
    public Animator lightAnim;
    public float lightTime;
    public static float lightTime2;
    public float cycleSpeed = 600.0f;
    public float cycleCounter = 0.0f;

    void Start()
    {
        theSunMoon = GetComponent<Light>();
        lightAnim.Play("Base Layer.LightCycle", 0, lightTime2);
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
        lightTime = lightAnim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    void OnDestroy(){
        lightTime2 = lightTime;
    }
}
