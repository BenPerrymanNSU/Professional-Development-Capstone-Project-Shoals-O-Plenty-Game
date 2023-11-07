using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using UnityEditor;

public class CampfireFunctionScript : MonoBehaviour
{
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
    public Slider waterSlider;
    public Slider cookSlider;
    public PlayerNeedStats playerNStats;
    private InvItemData consumableItemData;
    public InvItemContainer playerInventory;
    public InvScript_UI playerInventoryUI;
    public FollowingCanvas fCanvas;
    public string buttonString;
    public string fishName;
    public GameObject container;
    public GameObject worldCanvas;
    public int sliderVal;
    public static int sliderTempVal;
    public static bool sliderFirstTime;

    public void Start(){
        if(sliderTempVal != 0){
            var called = true;
            StartCoroutine(BoilWater(called));
        }
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
        CookButton.interactable = false;
        BoilButton.interactable = false;
        StartCoroutine(BoilWater(called));
    }

    public void CookButtonFunc(bool called){
        Menu.gameObject.SetActive(false);
        cookingMenu.gameObject.SetActive(true);
        CookableFishTest();
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

    public void FishCookButton(bool called){
        buttonString = EventSystem.current.currentSelectedGameObject.name.ToString();
        if(buttonString == carpButton.ToString().Split()[0]){
            fishName = "Carp";
            InventoryItemFinder(fishName);
        }
        if(buttonString == goldfishButton.ToString().Split()[0]){
            fishName = "Goldfish";
            InventoryItemFinder(fishName);
        }
        if(buttonString == starfishButton.ToString().Split()[0]){
            fishName = "Starfish";
            InventoryItemFinder(fishName);
        }
        if(buttonString == barracudaButton.ToString().Split()[0]){
            fishName = "Barracuda";
            InventoryItemFinder(fishName);
        }
        if(buttonString == bluefishButton.ToString().Split()[0]){
            fishName = "Bluefish";
            InventoryItemFinder(fishName);
        }
        if(buttonString == dolphinfishButton.ToString().Split()[0]){
            fishName = "Dolphinfish";
            InventoryItemFinder(fishName);
        }
        if(buttonString == bluefinButton.ToString().Split()[0]){
            fishName = "Bluefin";
            InventoryItemFinder(fishName);
        }
        if(buttonString == sunfishButton.ToString().Split()[0]){
            fishName = "Sunfish";
            InventoryItemFinder(fishName);
        }
        if(buttonString == swordfishButton.ToString().Split()[0]){
            fishName = "Swordfish";
            InventoryItemFinder(fishName);
        }
        StartCoroutine(CookFood(called));
    }

    public void InventoryItemFinder(string itemName){
        for(int i = 0; i < playerInventory.InvSystem2.InvLSlots.Count; i++){
            if(playerInventory.InvSystem2.InvLSlots[i].itemData2 != null){
                if(playerInventory.InvSystem2.InvLSlots[i].itemData2.ToString().Split()[0] == itemName){
                    playerInventory.InvSystem2.InvLSlots[i].ReduceItemStack(1);
                    playerInventoryUI.UpdateUISlot(playerInventory.InvSystem2.InvLSlots[i]);
                }
                break;
            }
        }
    }


    private IEnumerator BoilWater(bool called){
        var inventory = container.GetComponent<InvItemContainer>();
        worldCanvas.SetActive(true);
        for(int i = 0; i < 60; i++){
            if(sliderTempVal != 0){
                sliderVal = sliderTempVal;
                i = sliderVal;
                waterSlider.value -= sliderVal;
                fCanvas.SliderUpdater(sliderVal);
                sliderTempVal = 0;
                yield return new WaitForSeconds(1f);
            }
            else{
                sliderVal++;
                yield return new WaitForSeconds(1f);
                waterSlider.value -= 1;
                fCanvas.SliderUpdater(1);
            }
        }
        consumableItemData = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/Consumable/WaterContainer.asset");
        if (!inventory) yield break;
        if (inventory.InvSystem2.AddToInvSlot(consumableItemData, 1)){}
        waterSlider.value = 0;
        fCanvas.worldWaterSlider.value = 0;
        sliderTempVal = 0;
        called = false;
        CookButton.interactable = true;
        BoilButton.interactable = true;
        worldCanvas.SetActive(false);
    }

    private IEnumerator CookFood(bool called){
        var inventory = container.GetComponent<InvItemContainer>();
        BoilButton.interactable = false;
        worldCanvas.SetActive(true);
        for(int i = 0; i < 60; i++){
            if(sliderTempVal != 0){
                sliderVal = sliderTempVal;
                i = sliderVal;
                cookSlider.value -= sliderVal;
                fCanvas.SliderUpdater(sliderVal);
                sliderTempVal = 0;
                yield return new WaitForSeconds(1f);
            }
            else{
                sliderVal++;
                yield return new WaitForSeconds(1f);
                cookSlider.value -= 1;
                fCanvas.SliderUpdater(1);
            }
        }
        //consumableItemData = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/Consumable/WaterContainer.asset");
        //if (!inventory) yield break;
        //if (inventory.InvSystem2.AddToInvSlot(consumableItemData, 1)){}
        cookSlider.value = 0;
        fCanvas.worldWaterSlider.value = 0;
        sliderTempVal = 0;
        called = false;
        BoilButton.interactable = true;
        worldCanvas.SetActive(false);
    }

    void OnDestroy(){
        sliderTempVal = sliderVal;
    }

}
