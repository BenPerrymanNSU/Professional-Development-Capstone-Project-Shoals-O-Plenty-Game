using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
    public AudioSource reelSound;
    public GameObject ellipsis1;
    public GameObject ellipsis2;
    public GameObject ellipsis3;
    public Text FishPercentageText;
    public Image readyGoImage;
    public Image nothingText;
    public Sprite readyGoSprite;
    public Button goFishButton;
    public Button exitButton;

    public float requiredPercent = 0;
    public InvItemData[] itemDataEasyFish;
    public InvItemData[] itemDataMedFish;
    public InvItemData[] itemDataHardFish;
    public InvItemData[] itemDataMaterial;
    public InvItemData itemDataFishing;

    // At start instate fish and material arrays, these hold the item data for fish/materials that can be caught.
    void Start(){
        InvItemData[] itemDataEasyFish = new InvItemData[3];
        InvItemData[] itemDataMedFish = new InvItemData[3];
        InvItemData[] itemDataHardFish = new InvItemData[3];
        InvItemData[] itemDataMaterial = new InvItemData[3];
    }

    // Upon pressing this button, it will find the player camera and disable their ability to pause and open the inventory.
    // It will then subtract from the players hunger, thirst, and rest as a sort of payment to play the fishing minigame.
    // disables the fishing button and exit button to avoid potential bugs and begins the waiting process.
    public void GoFish(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        CameraController.GetComponentInChildren<PauseMenuFishing>().enabled = false;
        playerNStats.Hunger = playerNStats.SubtractFromStat(playerNStats.hungerBar, playerNStats.Hunger, 2f);
        playerNStats.Thirst = playerNStats.SubtractFromStat(playerNStats.thirstBar, playerNStats.Thirst, 2f);
        playerNStats.Rest = playerNStats.SubtractFromStat(playerNStats.restBar, playerNStats.Rest, 2f);
        goFishButton.interactable = false;
        exitButton.interactable = false;
        StartCoroutine(Ellipsis());
    }

    // Simulates waiting for a fish to bite the fishing line, once finished it show the player the result.
    private IEnumerator Ellipsis(){
        reelSound.Play();
        FishingRodMovement.SetBool("FishingBegin", true);
        yield return new WaitForSeconds(2f);
        ellipsis1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ellipsis2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ellipsis3.SetActive(true);
        Invoke("FindFish", 1.5f);
    }

    // Sets up important values and disables unecessary graphics before determining if the random number
    // falls within either the fish, material, or empty results.
    // If the result is a fish, it generates another random number to decide the fish's difficulty
    // it then will pull a random fish from the respective difficulty array and begin the gameplay portion.
    // If the result is a material, it randomly pulls from the material array and then begins the gameplay portion.
    // If the reult is nothing, then it resets the fishing rod's animations back to default and disables uncessary
    // objects. The nothing graphic is then shown via a coroutine.
    private void FindFish(){
        StopCoroutine("Ellipsis");
        var fishPercentage = 0.85f;
        var materialPercentage = 0.40f;

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
                SetFish(itemDataEasyFish);
            }
            else if(randomNum <= fishDifficultyMed){
                SetFish(itemDataMedFish);
            }
            else if(randomNum <= fishDifficultyHard){
                SetFish(itemDataHardFish);
            }
            else{
                FishChance.goodFish = 0.00f;
                FishChance.badFish = 1.00f;
                requiredPercent = 1.00f;
            }
            StartCoroutine(MoveFishKeys());
            Debug.Log("Passed MoveKeys");
        }
        else if(Random.value < materialPercentage){
            Invoke("ModelActivation", 0f);
            SetFish(itemDataMaterial);
            StartCoroutine(MoveFishKeys());
        }
        else{
            Line.SetActive(false);
            Bobber.SetActive(false);
            StartCoroutine(Nothing());
            reelSound.Stop();
            FishingRodMovement.SetBool("FishingBegin", false);
            FishingRodMovement.Play("Base Layer.FishingIdle", 0, 0f);
        }
    }

    // This function pulls a random fish/material from their respective arrays and then
    // sets the chances for spawning good and bad tokens for the gameplay portion.
    // the required percent is how well the player needs to do in the gameplay portion
    // to actually catch the fish and add it to their inventory.
    private void SetFish(InvItemData[] itemList){
        var randomRange = Random.Range(0, 3);
        itemDataFishing = itemList[randomRange];
        Debug.Log(itemDataFishing.itemDisplayedName);
        FishChance.goodFish = itemDataFishing.itemGoodFishChance;
        FishChance.badFish = itemDataFishing.itemBadFishChance;
        requiredPercent = itemDataFishing.itemRequiredPercent;
    }

    // Activates the models needed for the gameplay portion to begin.
    private void ModelActivation(){
        fishingUI.SetActive(true);
        fishingKeys.SetActive(true);
        PlayerBobber.SetActive(true);
        FishChance.placeFishTokens();
        FishPercentageText.gameObject.SetActive(true);
        readyGoImage.gameObject.SetActive(true);
    }

    // enables control of the player's fishing bobber when the sign says "GO"
    // begins the animation for the tiles holding the good and bad fish keys to move.
    private IEnumerator MoveFishKeys(){
        FishingRodMovement.SetBool("FishingRodFlingFinish", true);
        yield return new WaitForSeconds(3f);
        PlayerBobber.GetComponent<PlayerBobberController>().enabled = true;
        FishKeyMovement.SetBool("FishBool", true);
        FishKeyMovement.Update(0f);
        readyGoImage.sprite = readyGoSprite;
        yield return new WaitForSeconds(1f);
        readyGoImage.gameObject.SetActive(false);
        FishKeyMovement.SetBool("FishBool", false);
    }

    // pops up a graphic to inform the player that they did not get a fish/material.
    private IEnumerator Nothing(){
        nothingText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        nothingText.gameObject.SetActive(false);
        goFishButton.interactable = true;
        exitButton.interactable = true; 
    }
}
