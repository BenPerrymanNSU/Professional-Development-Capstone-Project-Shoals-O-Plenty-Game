using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEditor;

public class CampfireFunctionScript : MonoBehaviour
{
    public Image Menu;
    public Image Reticle;
    public Button BoilButton;
    public Button CookButton;
    public Button noButton;
    public Slider waterSlider;
    public PlayerNeedStats playerNStats;
    private InvItemData consumableItemData;
    public FollowingCanvas fCanvas;
    public GameObject container;
    public GameObject worldCanvas;
    public int sliderVal;
    public static int sliderTempVal;
    public static bool sliderFirstTime;

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
        BoilButton.interactable = false;
        called = false;
    }

    public void NoButton(bool called){
        Menu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        called = false;
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
        Debug.Log("Got Water!");
        waterSlider.value = 0;
        fCanvas.worldWaterSlider.value = 0;
        sliderTempVal = 0;
        called = false;
        CookButton.interactable = true;
        BoilButton.interactable = true;
        worldCanvas.SetActive(false);
    }

    void OnDestroy(){
        sliderTempVal = sliderVal;
    }

}
