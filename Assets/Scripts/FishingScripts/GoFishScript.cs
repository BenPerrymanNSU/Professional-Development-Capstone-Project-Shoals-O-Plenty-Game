using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

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
    public InvItemData[] itemDataEasyFish;
    public InvItemData[] itemDataMedFish;
    public InvItemData[] itemDataHardFish;
    public InvItemData[] itemDataMaterial;
    public InvItemData itemDataFishing;

    void Start(){
        FishKeyMovement.keepAnimatorControllerStateOnDisable = false;
        InvItemData[] itemDataEasyFish = new InvItemData[3];
        InvItemData[] itemDataMedFish = new InvItemData[3];
        InvItemData[] itemDataHardFish = new InvItemData[3];
        InvItemData[] itemDataMaterial = new InvItemData[3];
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
        var materialPercentage = 0.35f;

        var fishDifficultyEasy = 0.40f;
        var fishDifficultyMed = 0.75f;
        var fishDifficultyHard = 1.00f;

        ellipsis1.SetActive(false);
        ellipsis2.SetActive(false);
        ellipsis3.SetActive(false);

        if(Random.value < fishPercentage){
            Invoke("ModelActivation", 0f);
            var randomNum = Random.value;
            Debug.Log(randomNum);

            if(randomNum <= fishDifficultyEasy){
                var randomRange = Random.Range(0, 3);
                Debug.Log(randomRange);
                itemDataFishing = itemDataEasyFish[randomRange];
                Debug.Log(itemDataFishing.itemDisplayedName);
                FishChance.goodFish = itemDataFishing.itemGoodFishChance;
                Debug.Log(itemDataFishing.itemGoodFishChance);
                FishChance.badFish = itemDataFishing.itemBadFishChance;
                Debug.Log(itemDataFishing.itemBadFishChance);
                requiredPercent = itemDataFishing.itemRequiredPercent;
                Debug.Log(itemDataFishing.itemRequiredPercent);
            }
            else if(randomNum <= fishDifficultyMed){
                var randomRange = Random.Range(0, 3);
                Debug.Log(randomRange);
                itemDataFishing = itemDataMedFish[randomRange];
                Debug.Log(itemDataFishing.itemDisplayedName);
                FishChance.goodFish = itemDataFishing.itemGoodFishChance;
                Debug.Log(itemDataFishing.itemGoodFishChance);
                FishChance.badFish = itemDataFishing.itemBadFishChance;
                Debug.Log(itemDataFishing.itemBadFishChance);
                requiredPercent = itemDataFishing.itemRequiredPercent;
                Debug.Log(itemDataFishing.itemRequiredPercent);
            }
            else if(randomNum <= fishDifficultyHard){
                var randomRange = Random.Range(0, 3);
                Debug.Log(randomRange);
                itemDataFishing = itemDataHardFish[randomRange];
                Debug.Log(itemDataFishing.itemDisplayedName);
                FishChance.goodFish = itemDataFishing.itemGoodFishChance;
                Debug.Log(itemDataFishing.itemGoodFishChance);
                FishChance.badFish = itemDataFishing.itemBadFishChance;
                Debug.Log(itemDataFishing.itemBadFishChance);
                requiredPercent = itemDataFishing.itemRequiredPercent;
                Debug.Log(itemDataFishing.itemRequiredPercent);
            }
            else{
                Debug.Log("Tough Luck");
                FishChance.goodFish = 0.00f;
                FishChance.badFish = 1.00f;
                requiredPercent = 1.00f;
            }
            StartCoroutine(MoveFishKeys());
        }
        else if(Random.value < materialPercentage){
            Invoke("ModelActivation", 0f);
            var randomRange = Random.Range(0, 3);
            Debug.Log(randomRange);
            itemDataFishing = itemDataMaterial[randomRange];
            Debug.Log(itemDataFishing.itemDisplayedName);
            FishChance.goodFish = itemDataFishing.itemGoodFishChance;
            Debug.Log(itemDataFishing.itemGoodFishChance);
            FishChance.badFish = itemDataFishing.itemBadFishChance;
            Debug.Log(itemDataFishing.itemBadFishChance);
            requiredPercent = itemDataFishing.itemRequiredPercent;
            Debug.Log(itemDataFishing.itemRequiredPercent);
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
