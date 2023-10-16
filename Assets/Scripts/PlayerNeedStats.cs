using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNeedStats : MonoBehaviour
{
    public float Hunger = 100f;
    public float Thirst = 100f;
    public float Rest = 100f;
    public ClockScript clockTimer;
    private bool statLoweringCD = false;

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
}
