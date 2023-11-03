using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class ResultFishing : MonoBehaviour
{
    public FishKeyMover fishMove;
    public Animator FishKeyMovement;
    public Animator FishingRodMovement;
    public FishCollision fishCol;
    public PlayerBobberController bobberPlayer;
    public GameObject fishingUI;
    public GameObject PlayerBobber;
    public GameObject fishingKeys;
    public GameObject Line;
    public GameObject Bobber;
    private GameObject Key2;

    public Text FishPercentageText;
    public Image readyGoImage;
    public Sprite readyGoSprite;
    public Button goFishButton;
    public Button exitButton;

    public FishCollision resultGrabPercent;
    public GoFishScript difficultyPercent;
    public GoFishScript fishResultData;
    public GameObject container;
    public int numOfFishCaught = 0;

    public void CheckIfFishIsCaught(){
        FishingRodMovement.SetBool("FishingRodFlingFinish", false);
        FishingRodMovement.SetBool("FishingBegin", false);
        FishingRodMovement.SetBool("FishingGameOver", true);
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
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        FishKeyMovement.keepAnimatorControllerStateOnDisable = false;
        FishPercentageText.gameObject.SetActive(false);
        readyGoImage.sprite = readyGoSprite;
        readyGoImage.gameObject.SetActive(false);
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
        fishingKeys.SetActive(false);
        FishingRodMovement.SetBool("FishingGameOver", false);
        FishingRodMovement.Play("Base Layer.FishingIdle", 0, 0f);
    }

}
