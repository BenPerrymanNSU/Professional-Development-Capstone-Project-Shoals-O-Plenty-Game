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
    public GameObject fishingKeys;
    public Animator FishKeyMovement;
    public Animator FishingRodMovement;

    public PlayerNeedStats playerNStats;
    public GameObject Line;
    public GameObject Bobber;
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
        InvItemData[] itemDataEasyFish = new InvItemData[3];
        InvItemData[] itemDataMedFish = new InvItemData[3];
        InvItemData[] itemDataHardFish = new InvItemData[3];
        InvItemData[] itemDataMaterial = new InvItemData[3];
    }

    public void GoFish(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        playerNStats.Hunger = playerNStats.SubtractFromStat(playerNStats.hungerBar, playerNStats.Hunger, 5f);
        playerNStats.Thirst = playerNStats.SubtractFromStat(playerNStats.thirstBar, playerNStats.Thirst, 5f);
        playerNStats.Rest = playerNStats.SubtractFromStat(playerNStats.restBar, playerNStats.Rest, 5f);
        goFishButton.interactable = false;
        exitButton.interactable = false;
        StartCoroutine(Ellipsis());
    }

    private IEnumerator Ellipsis(){
        FishingRodMovement.SetBool("FishingBegin", true);
        yield return new WaitForSeconds(2f);
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
                itemDataFishing = itemDataEasyFish[randomRange];
                Debug.Log(itemDataFishing.itemDisplayedName);
                FishChance.goodFish = itemDataFishing.itemGoodFishChance;
                FishChance.badFish = itemDataFishing.itemBadFishChance;
                requiredPercent = itemDataFishing.itemRequiredPercent;
            }
            else if(randomNum <= fishDifficultyMed){
                var randomRange = Random.Range(0, 3);
                itemDataFishing = itemDataMedFish[randomRange];
                Debug.Log(itemDataFishing.itemDisplayedName);
                FishChance.goodFish = itemDataFishing.itemGoodFishChance;
                FishChance.badFish = itemDataFishing.itemBadFishChance;
                requiredPercent = itemDataFishing.itemRequiredPercent;
            }
            else if(randomNum <= fishDifficultyHard){
                var randomRange = Random.Range(0, 3);
                itemDataFishing = itemDataHardFish[randomRange];
                Debug.Log(itemDataFishing.itemDisplayedName);
                FishChance.goodFish = itemDataFishing.itemGoodFishChance;
                FishChance.badFish = itemDataFishing.itemBadFishChance;
                requiredPercent = itemDataFishing.itemRequiredPercent;
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
            itemDataFishing = itemDataMaterial[randomRange];
            Debug.Log(itemDataFishing.itemDisplayedName);
            FishChance.goodFish = itemDataFishing.itemGoodFishChance;
            FishChance.badFish = itemDataFishing.itemBadFishChance;
            requiredPercent = itemDataFishing.itemRequiredPercent;
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
        fishingKeys.SetActive(true);
        PlayerBobber.SetActive(true);
        FishChance.placeFishTokens();
        FishPercentageText.gameObject.SetActive(true);
        readyText.gameObject.SetActive(true);
    }

    private IEnumerator MoveFishKeys(){
        FishingRodMovement.SetBool("FishingRodFlingFinish", true);
        yield return new WaitForSeconds(3f);
        PlayerBobber.GetComponent<PlayerBobberController>().enabled = true;
        FishKeyMovement.SetBool("FishBool", true);
        FishKeyMovement.Update(0f);
        yield return new WaitForSeconds(0.5f);
        readyText.text = "GO";
        yield return new WaitForSeconds(1f);
        readyText.gameObject.SetActive(false);
        FishKeyMovement.SetBool("FishBool", false);
    }
}
