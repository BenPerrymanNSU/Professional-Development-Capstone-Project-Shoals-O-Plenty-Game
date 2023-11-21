using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNeedStats : MonoBehaviour
{
    public float Hunger = 100f;
    public float Thirst = 100f;
    public float Rest = 100f;
    public Slider hungerBar;
    public Slider thirstBar;
    public Slider restBar;
    private static float hungerTemp;
    private static float thirstTemp;
    private static float restTemp;
    public Image redWarning;
    public WinOrLoseScript gameCompletion;
    public ClockScript clockTimer;
    private bool statLoweringCD = false;
    private static bool firstActivation;
    private bool gameOverCalled = false;

    void Start(){
        hungerBar = GameObject.Find("HungerBar").GetComponent<Slider>();
        thirstBar = GameObject.Find("ThirstBar").GetComponent<Slider>();
        restBar = GameObject.Find("RestBar").GetComponent<Slider>();
        if(firstActivation == false){
            Hunger = AddToStat(hungerBar, Hunger, 100f);
            Thirst = AddToStat(thirstBar, Thirst, 100f);
            Rest = AddToStat(restBar, Rest, 100f);
            firstActivation = true;
            Debug.Log("First Activation");
        }
        else{
            Hunger = hungerTemp;
            AddToStatBar(hungerBar, hungerTemp);
            Thirst = thirstTemp;
            AddToStatBar(thirstBar, thirstTemp);
            Rest = restTemp;
            AddToStatBar(restBar, restTemp);
        }
    }

    void Update(){
        if((clockTimer.calcMinute == 30f || clockTimer.calcMinute == 59f) && statLoweringCD == false){
            Hunger = SubtractFromStat(hungerBar, Hunger, 1f);
            Thirst = SubtractFromStat(thirstBar, Thirst, 1f);
            Rest = SubtractFromStat(restBar, Rest, 1f);
            statLoweringCD = true;
        }
        else if(clockTimer.calcMinute == 15f || clockTimer.calcMinute == 45f ){
            statLoweringCD = false;
        }

    }

    void FixedUpdate(){
        if(Hunger <= 20 && gameOverCalled == false || Thirst <= 20 && gameOverCalled == false || Rest <= 20 && gameOverCalled == false){
            redWarning.gameObject.SetActive(true);
        }
        else{
            redWarning.gameObject.SetActive(false);
        }

        if(Hunger == 0 && gameOverCalled == false || Thirst == 0 && gameOverCalled == false || Rest == 0 && gameOverCalled == false){
            StartCoroutine("GameOverCheck", 0f);
        }
    }

    public float AddToStat(Slider needStatBar, float needStat, float increaseStatAmount){
        needStat += increaseStatAmount;
        if(needStat > 100f){
            needStat = 100f;
        }
        else if(needStat < 0){
            needStat = 0;
        }
        AddToStatBar(needStatBar, needStat);
        return needStat;
    }

    public float SubtractFromStat(Slider needStatBar, float needStat, float increaseStatAmount){
        needStat -= increaseStatAmount;
        if(needStat > 100f){
            needStat = 100f;
        }
        else if(needStat < 0){
            needStat = 0;
        }
        AddToStatBar(needStatBar, needStat);
        return needStat;
    }

    public void AddToStatBar(Slider needStatBar, float addStatAmount){
        needStatBar.value = addStatAmount;
    }

    private IEnumerator GameOverCheck(){
        gameOverCalled = true;
        yield return new WaitForSeconds(.1f);
        Hunger = 100f;
        hungerBar.value = 100f;
        Thirst = 100f;
        thirstBar.value = 100f;
        Rest = 100f;
        restBar.value = 100f;
        Hunger = SubtractFromStat(hungerBar, Hunger, 35f);
        Thirst = SubtractFromStat(thirstBar, Thirst, 35f);
        Rest = SubtractFromStat(restBar, Rest, 35f);
        gameCompletion.WinOrLose(false);
    }

    void OnDestroy(){
        hungerTemp = Hunger;
        thirstTemp = Thirst;
        restTemp = Rest;
    }
}
