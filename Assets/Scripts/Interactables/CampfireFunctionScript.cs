using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class CampfireFunctionScript : MonoBehaviour
{
    public GameObject container;
    public GameObject worldCanvas;

    public Image Menu;
    public Image cookingMenu;
    public Image Reticle;
    public Button BoilButton;
    public Button CookButton;
    public Button noButton;
    public Button carpButton;
    public Button goldfishButton;
    public Button starfishButton;
    public Button barracudaButton;
    public Button bluefishButton;
    public Button dolphinfishButton;
    public Button bluefinButton;
    public Button sunfishButton;
    public Button swordfishButton;
    public Button fishingSceneButton;
    public Slider waterSlider;
    public Slider cookSlider;
    public List<Button> fishButtons;

    public AudioSource cookSound;
    public AudioSource boilSound;
    public AudioSource completeCookBoil;

    public PlayerNeedStats playerNStats;
    private InvItemData consumableItemData;
    public InvItemContainer playerInventory;
    public InvScript_UI playerInventoryUI;
    public FollowingCanvas fCanvas;

    private string[] existingFishNames = {"Carp", "Goldfish", "Starfish", "Barracuda", "Bluefish", "Dolphinfish", "Bluefin", "Sunfish", "Swordfish"};
    private string buttonString;
    private string fishName;
    private string scriptableObjectPath;
    public int sliderVal;
    private int fishButtonListSize = 9;
    public static int sliderWaterTempVal;
    public static int sliderCookTempVal;
    public static bool sliderFirstTime;

    public void Start(){
        fishButtons = new List<Button>(fishButtonListSize);
        fishButtons.Add(carpButton);
        fishButtons.Add(goldfishButton);
        fishButtons.Add(starfishButton);
        fishButtons.Add(barracudaButton);
        fishButtons.Add(bluefishButton);
        fishButtons.Add(dolphinfishButton);
        fishButtons.Add(bluefinButton);
        fishButtons.Add(sunfishButton);
        fishButtons.Add(swordfishButton);
    }

    public void ScriptFunction(bool called){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        if (called == true){
            Menu.gameObject.SetActive(true);
            Reticle.gameObject.SetActive(false);
            CameraController.GetComponent<PlayerPOV>().enabled = false;
            CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            called = false;
        }
        else{
            Menu.gameObject.SetActive(false);
            Reticle.gameObject.SetActive(true);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CameraController.GetComponent<PlayerPOV>().enabled = true;
            CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
            called = false;
        }
        
    }

    public void BoilButtonFunc(bool called){
        var cookOrBoil = "Boil";
        BoilButton.interactable = false;
        fishingSceneButton.interactable = false;
        fCanvas.WaterSliderEnabled();
        StartCoroutine(CampfireTimer(sliderCookTempVal, sliderVal, waterSlider, boilSound, cookOrBoil, called));
    }

    public void CookButtonFunc(bool called){
        Menu.gameObject.SetActive(false);
        CookableFishTest();
        cookingMenu.gameObject.SetActive(true);
    }

    private void CookFood(bool called){
        var cookOrBoil = "Cook";
        fishingSceneButton.interactable = false;
        carpButton.interactable = false;
        goldfishButton.interactable = false;
        starfishButton.interactable = false;
        barracudaButton.interactable = false;
        bluefishButton.interactable = false;
        dolphinfishButton.interactable = false;
        bluefinButton.interactable = false;
        sunfishButton.interactable = false;
        swordfishButton.interactable = false;
        CookButton.interactable = false;
        fCanvas.CookSliderEnabled();
        StartCoroutine(CampfireTimer(sliderCookTempVal, sliderVal, cookSlider, cookSound, cookOrBoil, called));
    }

    public void NoButton(bool called){
        Menu.gameObject.SetActive(false);
        cookingMenu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        called = false;
    }

    public void BackButton(bool called){
        cookingMenu.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
    }

    public void CookableFishTest(){
        playerInventory.CheckInv();
        GreyOutButton(carpButton, playerInventory.fish0);
        GreyOutButton(goldfishButton, playerInventory.fish1);
        GreyOutButton(starfishButton, playerInventory.fish2);
        GreyOutButton(barracudaButton, playerInventory.fish3);
        GreyOutButton(bluefishButton, playerInventory.fish4);
        GreyOutButton(dolphinfishButton, playerInventory.fish5);
        GreyOutButton(bluefinButton, playerInventory.fish6);
        GreyOutButton(sunfishButton, playerInventory.fish7);
        GreyOutButton(swordfishButton, playerInventory.fish8);
    }

    public void GreyOutButton(Button fishButton, bool buttonBool){
        if(buttonBool == false){
            fishButton.interactable = false;
        }
        else{
            fishButton.interactable = true;
        }
    }

    public void FishCookButton(bool called){
        buttonString = EventSystem.current.currentSelectedGameObject.name.ToString();
        for(int i = 0; i < 9; i++){
            Debug.Log(fishButtons[i]);
            if(buttonString == fishButtons[i].ToString().Split()[0]){
                fishName = existingFishNames[i];
                StartCoroutine(InventoryItemFinder(fishName));
            }
        }
        CookFood(called);
    }

    public IEnumerator InventoryItemFinder(string itemName){
        for(int i = 0; i < playerInventory.InvSystem2.InvLSlots.Count; i++){
            if(playerInventory.InvSystem2.InvLSlots[i].itemData2 != null){
                if(playerInventory.InvSystem2.InvLSlots[i].itemData2.ToString().Split()[0] == itemName){
                    scriptableObjectPath = playerInventory.InvSystem2.InvLSlots[i].itemData2.ToString().Split()[0];
                    if (!playerInventory) yield break;
                    if (playerInventory.InvSystem2.AddToInvSlot(playerInventory.InvSystem2.InvLSlots[i].itemData2, -1)){}
                    break;
                }
            }
        }
    }

    public IEnumerator CampfireTimer(int sliderTempVal, int campSliderVal, Slider campSlider, AudioSource campSound, string identity, bool called){
        var inventory = container.GetComponent<InvItemContainer>();
        var processID = 0;
        if(identity == "Cook"){
            processID = 1;
        }
        else if(identity == "Boil"){
            processID = 2;
        }
        campSound.Play();
        for(int i = 0; i < 60; i++){
            if(sliderTempVal != 0){
                campSliderVal = sliderTempVal;
                i = campSliderVal;
                campSlider.value -= campSliderVal;
                fCanvas.UpdateSlider(processID, 1);
                sliderTempVal = 0;
                yield return new WaitForSeconds(1f);
            }
            else{
                campSliderVal++;
                yield return new WaitForSeconds(1f);
                campSlider.value -= 1;
                fCanvas.UpdateSlider(processID, 1);
            }
        }
        campSliderVal = 0;
        campSlider.value = 0;
        sliderTempVal = 0;
        
        if(identity == "Cook"){
            consumableItemData = Resources.Load<InvItemData>("ScriptedObjects/Consumable/" + "Cooked" + scriptableObjectPath);
            if (!inventory) yield break;
            if (inventory.InvSystem2.AddToInvSlot(consumableItemData, 1)){}
            fCanvas.worldCookSlider.value = 0;
            called = false;
            CookableFishTest();
            fCanvas.CallDisableCoroutine(1);
            CookButton.interactable = true;
        }
        else if(identity == "Boil"){
            consumableItemData = Resources.Load<InvItemData>("ScriptedObjects/Consumable/WaterContainer");
            if (!inventory) yield break;
            if (inventory.InvSystem2.AddToInvSlot(consumableItemData, 1)){}
            fCanvas.worldWaterSlider.value = 0;
            called = false;
            fCanvas.CallDisableCoroutine(2);
            BoilButton.interactable = true;
        }

        fishingSceneButton.interactable = true;
        campSound.Stop();
        completeCookBoil.Play();
        
    }



}
