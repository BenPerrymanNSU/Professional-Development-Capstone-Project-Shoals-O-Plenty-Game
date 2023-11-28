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

    // Upon activation find stat bar graphics and set them accordingly.
    // If first activation then set bar graphics and interal values to be full.
    // Else apply previously saved values from static versions and update bar graphics.
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

    // As the game is played slowly reduce the player's hunger, thirst, and rest
    // in accordance with the interal clock. Every in-game 59 seconds reduces the
    // players stats by 1.
    void Update(){
        if((clockTimer.calcMinute == 59f) && statLoweringCD == false){
            Hunger = SubtractFromStat(hungerBar, Hunger, 2f);
            Thirst = SubtractFromStat(thirstBar, Thirst, 2f);
            Rest = SubtractFromStat(restBar, Rest, 2f);
            statLoweringCD = true;
        }
        else if(clockTimer.calcMinute == 45f ){
            statLoweringCD = false;
        }

    }

    // Upon any of the player's stats reaching 20 or below, activate red filter to indicate danger.
    // If any of the player's stats reaches 0, call the game over coroutine to start transition to the win/lose screen.
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

    // Increases passed in player stat by a passed in amount and updates the associated 
    // bar graphic. Player stats can't go above 100 or below 0.
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

    // Decreases passed in player stat by a passed in amount and updates the associated 
    // bar graphic. Player stats can't go above 100 or below 0.
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

    // Increases the passed in stat bar slider graphic value.
    public void AddToStatBar(Slider needStatBar, float addStatAmount){
        needStatBar.value = addStatAmount;
    }

    // Checks to see if the player has died due to their stats reaching 0.
    // when this triggers, sets stat to full then reduce them by 35 as a
    // punishment they will see when re-entering the game.
    // Finally, this transports to the win/lose screen scene.
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

    // When the scene is changed this stores the players current hunger,
    // thirst, and rest stats into static version to save between scenes.
    // these are applied at the start to ensure the players stats will 
    // continue to reduce as the game is played.
    void OnDestroy(){
        hungerTemp = Hunger;
        thirstTemp = Thirst;
        restTemp = Rest;
    }
}
