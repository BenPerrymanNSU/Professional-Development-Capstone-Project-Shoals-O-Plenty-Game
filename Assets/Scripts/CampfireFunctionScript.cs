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
    private string buttonString;
    private string fishName;
    private string scriptableObjectPath;
    public GameObject container;
    public GameObject worldCanvas;
    public int sliderVal;
    public static int sliderWaterTempVal;
    public static int sliderCookTempVal;
    public static bool sliderFirstTime;

    public void Start(){
        if(sliderWaterTempVal != 0){
            var called = true;
            StartCoroutine(BoilWater(called));
        }
        else if(sliderCookTempVal != 0){
            var called = true;
            StartCoroutine(CookFood(called));
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
        CookableFishTest();
        cookingMenu.gameObject.SetActive(true);
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
             StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == goldfishButton.ToString().Split()[0]){
            fishName = "Goldfish";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == starfishButton.ToString().Split()[0]){
            fishName = "Starfish";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == barracudaButton.ToString().Split()[0]){
            fishName = "Barracuda";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == bluefishButton.ToString().Split()[0]){
            fishName = "Bluefish";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == dolphinfishButton.ToString().Split()[0]){
            fishName = "Dolphinfish";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == bluefinButton.ToString().Split()[0]){
            fishName = "Bluefin";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == sunfishButton.ToString().Split()[0]){
            fishName = "Sunfish";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        if(buttonString == swordfishButton.ToString().Split()[0]){
            fishName = "Swordfish";
            StartCoroutine(InventoryItemFinder(fishName));
        }
        StartCoroutine(CookFood(called));
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


    private IEnumerator BoilWater(bool called){
        var inventory = container.GetComponent<InvItemContainer>();
        worldCanvas.SetActive(true);
        fCanvas.WaterSliderEnabled();
        for(int i = 0; i < 60; i++){
            if(sliderWaterTempVal != 0){
                sliderVal = sliderWaterTempVal;
                i = sliderVal;
                waterSlider.value -= sliderVal;
                fCanvas.WaterSliderUpdater(sliderVal);
                sliderWaterTempVal = 0;
                yield return new WaitForSeconds(1f);
            }
            else{
                sliderVal++;
                yield return new WaitForSeconds(1f);
                waterSlider.value -= 1;
                fCanvas.WaterSliderUpdater(1);
            }
        }
        consumableItemData = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/Consumable/WaterContainer.asset");
        if (!inventory) yield break;
        if (inventory.InvSystem2.AddToInvSlot(consumableItemData, 1)){}
        waterSlider.value = 0;
        fCanvas.worldWaterSlider.value = 0;
        sliderWaterTempVal = 0;
        called = false;
        CookButton.interactable = true;
        BoilButton.interactable = true;
        fCanvas.CallDisableCoroutine();
        worldCanvas.SetActive(false);
    }

    private IEnumerator CookFood(bool called){
        var inventory = container.GetComponent<InvItemContainer>();
        carpButton.interactable = false;
        goldfishButton.interactable = false;
        starfishButton.interactable = false;
        barracudaButton.interactable = false;
        bluefishButton.interactable = false;
        dolphinfishButton.interactable = false;
        bluefinButton.interactable = false;
        sunfishButton.interactable = false;
        swordfishButton.interactable = false;
        BoilButton.interactable = false;
        worldCanvas.SetActive(true);
        fCanvas.CookSliderEnabled();
        for(int i = 0; i < 60; i++){
            if(sliderCookTempVal != 0){
                sliderVal = sliderCookTempVal;
                i = sliderVal;
                cookSlider.value -= sliderVal;
                fCanvas.CookSliderUpdater(sliderVal);
                sliderCookTempVal = 0;
                yield return new WaitForSeconds(1f);
            }
            else{
                sliderVal++;
                yield return new WaitForSeconds(1f);
                cookSlider.value -= 1;
                fCanvas.CookSliderUpdater(1);
            }
        }
        consumableItemData = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/Consumable/" + "Cooked" + scriptableObjectPath + ".asset");
        if (!inventory) yield break;
        if (inventory.InvSystem2.AddToInvSlot(consumableItemData, 1)){}
        cookSlider.value = 0;
        fCanvas.worldCookSlider.value = 0;
        sliderCookTempVal = 0;
        called = false;
        CookableFishTest();
        BoilButton.interactable = true;
        fCanvas.CallDisableCoroutine();
        worldCanvas.SetActive(false);
    }

    void OnDestroy(){
        sliderWaterTempVal = sliderVal;
        sliderCookTempVal = sliderVal;
    }

}
