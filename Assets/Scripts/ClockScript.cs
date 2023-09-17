using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour
{
    const int hoursInDay = 24, minutesInHour = 60;
    public float dayCycle = 30f;
    float playTime = 0f;
    float currentTime = 0f;
    public float calcHour = 0f;
    public float calcMinute = 0f;
    string twentyFourHourString;

    public Text clockDisplay;

    void Update(){
        playTime += Time.deltaTime;
        currentTime = playTime % dayCycle;
        calcHour = Mathf.FloorToInt(ObtainHour());
        calcMinute = Mathf.FloorToInt(ObtainMinute());
        twentyFourHourString = calcHour.ToString("00") + ":" + calcMinute.ToString("00");
        clockDisplay.text = twentyFourHourString;
    }

    float ObtainHour(){
        return 6 + currentTime * hoursInDay / dayCycle;
    }

    float ObtainMinute(){
        return (currentTime * hoursInDay * minutesInHour / dayCycle) % minutesInHour;
    }

}
