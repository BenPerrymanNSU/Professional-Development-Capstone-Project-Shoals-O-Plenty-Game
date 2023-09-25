using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoFishScript : MonoBehaviour
{
    public FishKeyMover FishChance;
    public GameObject fishingUI;
    public GameObject PlayerBobber;
    public GameObject fishingKey0;
    public GameObject fishingKey1;
    public GameObject fishingKey2;
    public GameObject fishingKey3;
    public GameObject fishingKey4;
    public GameObject fishingKey5;
    public GameObject fishingKey6;
    public GameObject fishingKey7;
    public GameObject fishingKey8;
    public GameObject fishingKey9;
    public GameObject Line;
    public GameObject Bobber;
    public Animator FishKeyMovement;

    public GameObject ellipsis1;
    public GameObject ellipsis2;
    public GameObject ellipsis3;
    public Text FishPercentageText;
    public Text readyText;
    public Button goFishButton;
    public Button exitButton;

    public float requiredPercent = 0;

    void Start(){
        FishKeyMovement.keepAnimatorControllerStateOnDisable = false;
    }

    public void GoFish(){
        Line.SetActive(true);
        Bobber.SetActive(true);
        goFishButton.interactable = false;
        exitButton.interactable = false;
        StartCoroutine(Ellipsis());
    }

    private IEnumerator Ellipsis(){
        ellipsis1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ellipsis2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ellipsis3.SetActive(true);
        Invoke("FindFish", 1.5f);
    }

    private void FindFish(){
        StopCoroutine("Ellipsis");
        var fishPercentage = 0.85f;
        var fishDifficultyEasy = 0.40f;
        var fishDifficultyMed = 0.75f;
        var fishDifficultyHard = 1.00f;

        ellipsis1.SetActive(false);
        ellipsis2.SetActive(false);
        ellipsis3.SetActive(false);

        if(Random.value < fishPercentage){
            Invoke("ModelActivation", 0f);
            Debug.Log("Fish");
            var randomNum = Random.value;
            Debug.Log(randomNum);
            if(randomNum <= fishDifficultyEasy){
                Debug.Log("easy");
                FishChance.goodFish = 0.55f;
                FishChance.badFish = 0.75f;
                requiredPercent = 0.30f;
            }
            else if(randomNum <= fishDifficultyMed){
                Debug.Log("Med");
                FishChance.goodFish = 0.30f;
                FishChance.badFish = 0.75f;
                requiredPercent = 0.60f;
            }
            else if(randomNum <= fishDifficultyHard){
                Debug.Log("Hard");
                FishChance.goodFish = 0.10f;
                FishChance.badFish = 0.60f;
                requiredPercent = 0.90f;
            }
            else{
                Debug.Log("Tough Luck");
                FishChance.goodFish = 0.00f;
                FishChance.badFish = 1.00f;
                requiredPercent = 1.00f;
            }
            StartCoroutine(MoveFishKeys());
        }
        else{
            Debug.Log("Nothin");
            Line.SetActive(false);
            Bobber.SetActive(false);
            goFishButton.interactable = true;
            exitButton.interactable = true; 
        }
    }

    private void ModelActivation(){
        fishingUI.SetActive(true);
        PlayerBobber.SetActive(true);
        fishingKey0.SetActive(true);
        fishingKey1.SetActive(true);
        fishingKey2.SetActive(true);
        fishingKey3.SetActive(true);
        fishingKey4.SetActive(true);
        fishingKey5.SetActive(true);
        fishingKey6.SetActive(true);
        fishingKey7.SetActive(true);
        fishingKey8.SetActive(true);
        fishingKey9.SetActive(true);
        FishChance.placeFishTokens();
        FishPercentageText.gameObject.SetActive(true);
        readyText.gameObject.SetActive(true);
    }

    private IEnumerator MoveFishKeys(){
        yield return new WaitForSeconds(3f);
        PlayerBobber.GetComponent<PlayerBobberController>().enabled = true;
        FishKeyMovement.SetBool("FishBool", true);
        yield return new WaitForSeconds(0.5f);
        readyText.text = "GO";
        yield return new WaitForSeconds(1f);
        readyText.gameObject.SetActive(false);
        FishKeyMovement.SetBool("FishBool", false);
    }
}
