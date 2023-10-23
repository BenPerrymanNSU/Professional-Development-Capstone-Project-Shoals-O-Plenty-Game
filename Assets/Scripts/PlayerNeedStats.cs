using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNeedStats : MonoBehaviour
{
    public float Hunger = 100f;
    public float Thirst = 100f;
    public float Rest = 100f;
    public RectTransform hungerBar;
    public RectTransform thirstBar;
    public RectTransform restBar;
    private static float hungerTemp;
    private static float thirstTemp;
    private static float restTemp;
    private static float maxBarTemp;
    public float statHungerTracker;
    public float statThirstTracker;
    public float statRestTracker;
    public static float statHungerTrackerTemp;
    public static float statThirstTrackerTemp;
    public static float statRestTrackerTemp;
    public ClockScript clockTimer;
    private bool statLoweringCD = false;
    private static bool firstActivation;

    void Start(){
        hungerBar = GameObject.Find("HungerBar").GetComponent<RectTransform>();
        thirstBar = GameObject.Find("ThirstBar").GetComponent<RectTransform>();
        restBar = GameObject.Find("RestBar").GetComponent<RectTransform>();
        if(firstActivation == false){
            Hunger = 100f;
            Thirst = 100f;
            Rest = 100f;
            statHungerTracker = 0;
            statThirstTracker = 0;
            statRestTracker = 0;
            maxBarTemp = hungerBar.offsetMin.x;
            firstActivation = true;
            Debug.Log("First Activation");
        }
        else{
            Hunger = hungerTemp;
            Thirst = thirstTemp;
            Rest = restTemp;
            statHungerTracker = statHungerTrackerTemp;
            statThirstTracker = statThirstTrackerTemp;
            statRestTracker = statRestTrackerTemp;
            SubtractFromStatBar(hungerBar, statHungerTracker);
            SubtractFromStatBar(thirstBar, statThirstTracker);
            SubtractFromStatBar(restBar, statRestTracker);

        }
    }

    void Update(){
        if((clockTimer.calcMinute == 30f || clockTimer.calcMinute == 59f) && statLoweringCD == false){
            Hunger = SubtractFromStat(Hunger, 1f);
            Thirst = SubtractFromStat(Thirst, 1f);
            Rest = SubtractFromStat(Rest, 1f);
            SubtractFromStatBar(hungerBar, 1f);
            SubtractFromStatBar(thirstBar, 1f);
            SubtractFromStatBar(restBar, 1f);
            statHungerTracker = AddToTracker(statHungerTracker, 1f);
            statThirstTracker = AddToTracker(statThirstTracker, 1f);
            statRestTracker = AddToTracker(statRestTracker, 1f);
            statLoweringCD = true;
        }
        else if(clockTimer.calcMinute == 15f || clockTimer.calcMinute == 45f ){
            statLoweringCD = false;
        }
    }

    public float AddToStat(float needStat, float increaseStatAmount){
        needStat += increaseStatAmount;
        if(needStat > 100f){
            needStat = 100f;
        }
        else if(needStat < 0){
            needStat = 0;
        }
        return needStat;
    }

    public float SubtractFromStat(float needStat, float increaseStatAmount){
        needStat -= increaseStatAmount;
        if(needStat > 100f){
            needStat = 100f;
        }
        else if(needStat < 0){
            needStat = 0;
        }
        return needStat;
    }

    public void AddToStatBar(RectTransform needStatBar, float addStatAmount){
        needStatBar.offsetMin = new Vector2(needStatBar.offsetMin.x, needStatBar.offsetMin.y);
        needStatBar.offsetMin = new Vector2((needStatBar.offsetMin.x) - addStatAmount, needStatBar.offsetMin.y);
        if(needStatBar.offsetMin.x < maxBarTemp){
            needStatBar.offsetMin = new Vector2(maxBarTemp, needStatBar.offsetMin.y);
        }
        else if(needStatBar.offsetMin.x > 1806.667f){
            needStatBar.offsetMin = new Vector2(1806.667f, needStatBar.offsetMin.y);
        }

    }

    public void SubtractFromStatBar(RectTransform needStatBar, float subStatAmount){
        needStatBar.offsetMin = new Vector2(needStatBar.offsetMin.x, needStatBar.offsetMin.y);
        needStatBar.offsetMin = new Vector2((needStatBar.offsetMin.x) + subStatAmount, needStatBar.offsetMin.y);
        if(needStatBar.offsetMin.x < maxBarTemp){
            needStatBar.offsetMin = new Vector2(maxBarTemp, needStatBar.offsetMin.y);
        }
        else if(needStatBar.offsetMin.x > 1806.667f){
            needStatBar.offsetMin = new Vector2(1806.667f, needStatBar.offsetMin.y);
        }
    }

    public float AddToTracker(float needTracker, float increaseTracker){
        needTracker += increaseTracker;
        if(needTracker > 100f){
            needTracker = 100f;
        }
        else if(needTracker < 0){
            needTracker = 0;
        }
        return needTracker;
    }

    public float SubtractFromTracker(float needTracker, float increaseTracker){
        needTracker -= increaseTracker;
        if(needTracker > 100f){
            needTracker = 100f;
        }
        else if(needTracker < 0){
            needTracker = 0;
        }
        return needTracker;
    }




/*
    public float TrackerCheck(RectTransform needStatBar, float statTracker){
        if(statTracker >= 0){
            statTracker = SubtractFromStatBar(needStatBar, statTracker, statTracker);
        }
        else if(statTracker < 0){
            statTracker = AddToStatBar(needStatBar, statTracker, statTracker);
        }
        Debug.Log(statTracker);
        return statTracker;
    }
*/
    void OnDestroy(){
        hungerTemp = Hunger;
        thirstTemp = Thirst;
        restTemp = Rest;
        statHungerTrackerTemp = statHungerTracker;
        statThirstTrackerTemp = statThirstTracker;
        statRestTrackerTemp = statRestTracker;
    }
}
