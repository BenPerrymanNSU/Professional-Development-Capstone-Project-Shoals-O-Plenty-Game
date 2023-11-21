using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
    public AudioSource reelSound;
    public AudioSource completedSound;
    private GameObject Key2;

    public Text FishPercentageText;
    public Image readyGoImage;
    public Image resultMenu;
    public Image fishPic;
    public Sprite readyGoSprite;
    public Button goFishButton;
    public Button exitButton;

    public FishCollision resultGrabPercent;
    public GoFishScript difficultyPercent;
    public GoFishScript fishResultData;
    public GameObject container;

    public void CheckIfFishIsCaught(){
        FishingRodMovement.SetBool("FishingRodFlingFinish", false);
        FishingRodMovement.SetBool("FishingBegin", false);
        FishingRodMovement.SetBool("FishingGameOver", true);
        var currentPercent = resultGrabPercent.fishCatchPercentage;
        var neededPercent = difficultyPercent.requiredPercent;

        if(currentPercent == 1.00f){
            ResultsMenuActivation(3);
        }
        else if(currentPercent >= neededPercent){
            ResultsMenuActivation(2);
        }
        else{
            ResultsMenuActivation(1);
        }
    }

    private void ResultsMenuActivation(int outcomeNum){
        var resultData = fishResultData.itemDataFishing;
        reelSound.Stop();
        completedSound.Play();
        resultMenu.gameObject.SetActive(true);
        fishPic.sprite = resultData.itemIcon;
        resultMenu.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        resultMenu.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        resultMenu.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(false);
        switch(outcomeNum){
            case 3:
                resultMenu.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                resultMenu.transform.GetChild(1).gameObject.SetActive(true);
                GiveItem();
                break;
            case 2:
                resultMenu.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                resultMenu.transform.GetChild(1).gameObject.SetActive(true);
                GiveItem();
                break;
            case 1:
                resultMenu.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                resultMenu.transform.GetChild(1).gameObject.SetActive(false);
                StartCoroutine("ShowResults", 0f); 
                break;
            default:
                Debug.Log("Something Didn't Work!");
                break;
        }
    }

    private void GiveItem(){
        var inventory = container.GetComponent<InvItemContainer>();
        var resultData = fishResultData.itemDataFishing;
        if (!inventory) return;
        if (inventory.InvSystem2.AddToInvSlot(resultData, 1)){}
        StartCoroutine("ShowResults", 0f);
    }

    private IEnumerator ShowResults(){
        FishPercentageText.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Invoke("TheGreatReset", 0.5f);
    }


    private void TheGreatReset(){
        Debug.Log("Reset!");
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        CameraController.GetComponentInChildren<PauseMenuFishing>().enabled = true;
        FishKeyMovement.keepAnimatorControllerStateOnDisable = false;
        readyGoImage.sprite = readyGoSprite;
        readyGoImage.gameObject.SetActive(false);
        Line.SetActive(false);
        Bobber.SetActive(false);

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

        resultMenu.gameObject.SetActive(false);
        goFishButton.interactable = true;
        exitButton.interactable = true;
    }

}
