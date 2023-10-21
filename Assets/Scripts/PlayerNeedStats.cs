using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNeedStats : MonoBehaviour
{
    public float Hunger = 100f;
    public float Thirst = 100f;
    public float Rest = 100f;
    private Image hungerBar;
    private Image thirstBar;
    private Image restBar;
    public static float hungerTemp;
    public static float thirstTemp;
    public static float restTemp;
    public ClockScript clockTimer;
    private bool statLoweringCD = false;
    private static bool firstActivation;

    void Start(){
        if(firstActivation == false){
            Hunger = 100f;
            Thirst = 100f;
            Rest = 100f;
            firstActivation = true;
        }
        else{
            Hunger = hungerTemp;
            Thirst = thirstTemp;
            Rest = restTemp;
        }
    }

    void Update()
    {
        if((clockTimer.calcMinute == 30f || clockTimer.calcMinute == 59f) && statLoweringCD == false){
            Hunger -= 0.5f;
            Thirst -= 0.5f;
            Rest -= 0.5f;
            statLoweringCD = true;
        }
        else if(clockTimer.calcMinute == 15f || clockTimer.calcMinute == 45f ){
            statLoweringCD = false;
        }
    }

    void FixedUpdate(){
        if(Hunger > 100f){
            Hunger = 100f;
        }
        else if(Thirst > 100f){
            Thirst = 100f;
        }
        else if(Rest > 100f){
            Rest = 100f;
        }
        else if(Hunger < 0){
            Hunger = 0;
        }
        else if(Thirst < 0){
            Thirst = 0;
        }
        else if(Rest < 0){
            Rest = 0;
        }
    }

    void OnDestroy(){
        hungerTemp = Hunger;
        thirstTemp = Thirst;
        restTemp = Rest;
    }
}
