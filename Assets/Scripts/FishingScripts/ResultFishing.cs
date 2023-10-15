using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class ResultFishing : MonoBehaviour
{
    public FishKeyMover fishMove;
    public FishCollision fishCol;
    public PlayerBobberController bobberPlayer;
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
    private GameObject Key2;

    public Text FishPercentageText;
    public Text readyText;
    public Button goFishButton;
    public Button exitButton;

    public FishCollision resultGrabPercent;
    public GoFishScript difficultyPercent;
    public GoFishScript fishResultData;
    public GameObject container;
    public int numOfFishCaught = 0;

    public void CheckIfFishIsCaught(){
        var inventory = container.GetComponent<InvItemContainer>();
        var currentPercent = resultGrabPercent.fishCatchPercentage;
        var neededPercent = difficultyPercent.requiredPercent;
        var resultData = fishResultData.itemDataFishing;

        if(currentPercent == 1.00f){
            Debug.Log("Pure Victory!!!!!");
            numOfFishCaught++;
            if (!inventory) return;
            if (inventory.InvSystem2.AddToInvSlot(resultData, 1)){

            }
            Invoke("TheGreatReset", 0.5f);
        }
        else if(currentPercent >= neededPercent){
            Debug.Log("Goodjob!");
            numOfFishCaught++;
            if (!inventory) return;
            if (inventory.InvSystem2.AddToInvSlot(resultData, 1)){

            }
            Invoke("TheGreatReset", 0.5f);
        }
        else{
            Debug.Log("Need more practice...");
            Invoke("TheGreatReset", 0.5f);
            
        }
    }

    private void TheGreatReset(){
        Debug.Log("Reset!");
        FishPercentageText.gameObject.SetActive(false);
        readyText.text = "Ready?";
        readyText.gameObject.SetActive(false);
        Line.SetActive(false);
        Bobber.SetActive(false);
        goFishButton.interactable = true;
        exitButton.interactable = true;

        fishMove.FishingActive = false;
        fishMove.countGoodFish = 0;
        fishMove.countBadFish = 0;
        fishMove.minimumGoodFish = 10;
        fishMove.minimumGoodFishCleared = false;

        fishCol.fishCatchPercentage = 0.00f;
        fishCol.fishFound = false;

        bobberPlayer.upBobber = false;
        bobberPlayer.downBobber = false;
        bobberPlayer.midBobber = true;
        bobberPlayer.PlayerBobberMover.SetBool("ReturntoMid", false);
        bobberPlayer.PlayerBobberMover.SetBool("PlayerDown", false);
        bobberPlayer.PlayerBobberMover.SetBool("PlayerUp", false);

        fishingUI.SetActive(false);
        PlayerBobber.GetComponent<PlayerBobberController>().enabled = false;
        PlayerBobber.transform.position = new Vector3(4.50037193f,1.85964489f,2.80498505f);
        PlayerBobber.SetActive(false);
        fishingKey0.SetActive(false);
        fishingKey1.SetActive(false);
        fishingKey2.SetActive(false);
        fishingKey3.SetActive(false);
        fishingKey4.SetActive(false);
        fishingKey5.SetActive(false);
        fishingKey6.SetActive(false);
        fishingKey7.SetActive(false);
        fishingKey8.SetActive(false);
        fishingKey9.SetActive(false);
    }

}
