using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoatFunctionScript : MonoBehaviour
{
    public Image Menu;
    public Image Reticle;
    public Button noButton;
    public Button repairButton;
    public Button woodButton;
    public Button ropeButton;
    public Button rockButton;
    public Text menuWoodText;
    public Text menuRopeText;
    public Text menuRockText;
    public GameObject interchangableModel;
    public InvItemContainer playerInventory;
    public Animator fadingAnim;
    private string materialName;
    private string materialButtonString;
    private string scriptableObjectPath;
    private static bool firstLoad;
    private static bool level1Boat;
    private static bool level2Boat;
    private static bool level3Boat;
    private static int woodNeeded;
    private static int ropeNeeded;
    private static int rockNeeded;

    public void ScriptFunction(bool called){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        if (called == true){
            Menu.gameObject.SetActive(true);
            Reticle.gameObject.SetActive(false);
            CameraController.GetComponent<PlayerPOV>().enabled = false;
            CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            SetRepairCost();
            MaterialsTest();
            RepairButtonInteractable();
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

    public void Awake(){
        if(level1Boat == true){
            ChangeModel(0, 0, false, true);
        }
        if(level2Boat == true){
            interchangableModel.transform.GetChild(0).gameObject.SetActive(false);
            ChangeModel(0, 1, false, true);
        }
        if(level3Boat == true){
            interchangableModel.transform.GetChild(0).gameObject.SetActive(false);
            ChangeModel(1, 2, false, true);
        }
    }

    public void SetRepairCost(){
        if(firstLoad == false){
            SetFirstLevelBoatRepair();
            RepairButtonInteractable();
            level1Boat = true;
            firstLoad = true;
        }
        else{
            RepairButtonInteractable();
            menuWoodText.text = woodNeeded.ToString() + " X";
            menuRopeText.text = ropeNeeded.ToString() + " X";
            menuRockText.text = rockNeeded.ToString() + " X";
        }
    }

    public void IncreaseBoatLevel(){
        if(level1Boat == true){
            if(woodNeeded == 0 && ropeNeeded == 0 && rockNeeded == 0){
                Debug.Log("Level 1 Complete");
                var called = true;
                StartCoroutine(BoatTransition(called));
                level2Boat = true;
                level1Boat = false;
                StartCoroutine(BoatWait(0, 1, false, true));
                SetSecondLevelBoatRepair();
            }
        }
        if(level2Boat == true){
            if(woodNeeded == 0 && ropeNeeded == 0 && rockNeeded == 0){
                Debug.Log("Level 2 Complete");
                var called = true;
                StartCoroutine(BoatTransition(called));
                level3Boat = true;
                level2Boat = false;
                StartCoroutine(BoatWait(1, 2, false, true));
                SetThirdLevelBoatRepair();
            }
        }
        MaterialsTest();

        if(level3Boat == true){
            if(woodNeeded == 0 && ropeNeeded == 0 && rockNeeded == 0){
                Debug.Log("Win");
            }
        }
    }

    public void RepairButtonInteractable(){
        if(woodNeeded == 0 && ropeNeeded == 0 && rockNeeded == 0){
            repairButton.interactable = true;
        }
        else{
            repairButton.interactable = false;
        }
    }

    public void SetFirstLevelBoatRepair(){
        woodNeeded = Random.Range(1, 3);
        menuWoodText.text = woodNeeded.ToString() + " X";
        ropeNeeded = Random.Range(1, 3);
        menuRopeText.text = ropeNeeded.ToString() + " X";
        rockNeeded = Random.Range(1, 3);
        menuRockText.text = rockNeeded.ToString() + " X";
    }

    public void SetSecondLevelBoatRepair(){
        woodNeeded = Random.Range(3, 6);
        menuWoodText.text = woodNeeded.ToString() + " X";
        ropeNeeded = Random.Range(3, 6);
        menuRopeText.text = ropeNeeded.ToString() + " X";
        rockNeeded = Random.Range(3, 6);
        menuRockText.text = rockNeeded.ToString() + " X";
    }

    public void SetThirdLevelBoatRepair(){
        woodNeeded = Random.Range(6, 9);
        menuWoodText.text = woodNeeded.ToString() + " X";
        ropeNeeded = Random.Range(6, 9);
        menuRopeText.text = ropeNeeded.ToString() + " X";
        rockNeeded = Random.Range(6, 9);
        menuRockText.text = rockNeeded.ToString() + " X";
    }

    public void MaterialsTest(){
        playerInventory.CheckInv();
        if(woodNeeded != 0){
            GreyOutButton(woodButton, playerInventory.material9);
        }
        else{
            woodButton.interactable = false;
        }

        if(ropeNeeded != 0){
            GreyOutButton(ropeButton, playerInventory.material11);
        }
        else{
            ropeButton.interactable = false;
        }

        if(rockNeeded != 0){
            GreyOutButton(rockButton, playerInventory.material10);
        }
        else{
            rockButton.interactable = false;
        }
    }

    public void GreyOutButton(Button materialButton, bool buttonBool){
        if(buttonBool == false){
            materialButton.interactable = false;
        }
        else{
            materialButton.interactable = true;
        }
    }

public void MaterialButtonPressed(bool called){
        materialButtonString = EventSystem.current.currentSelectedGameObject.name.ToString();
        if(materialButtonString == woodButton.ToString().Split()[0]){
            materialName = "WoodPlank";
            StartCoroutine(InventoryItemFinder(materialName));
        }
        if(materialButtonString == ropeButton.ToString().Split()[0]){
            materialName = "Rope";
            StartCoroutine(InventoryItemFinder(materialName));
        }
        if(materialButtonString == rockButton.ToString().Split()[0]){
            materialName = "Rock";
            StartCoroutine(InventoryItemFinder(materialName));
        }
    }

    public IEnumerator InventoryItemFinder(string itemName){
        for(int i = 0; i < playerInventory.InvSystem2.InvLSlots.Count; i++){
            if(playerInventory.InvSystem2.InvLSlots[i].itemData2 != null){
                if(playerInventory.InvSystem2.InvLSlots[i].itemData2.ToString().Split()[0] == itemName){
                    scriptableObjectPath = playerInventory.InvSystem2.InvLSlots[i].itemData2.ToString().Split()[0];
                    if (!playerInventory) yield break;
                    if (playerInventory.InvSystem2.AddToInvSlot(playerInventory.InvSystem2.InvLSlots[i].itemData2, -1)){}
                    materialFunc(itemName);
                    MaterialsTest();
                    break;
                }
            }
        }
    }

    public void materialFunc(string itemName){
        MaterialsTest();
        if(itemName == "WoodPlank"){
            if(woodNeeded >= 0){
                woodNeeded--;
            }
            else{
                woodNeeded = 0;
                woodButton.interactable = false;
            }
            menuWoodText.text = woodNeeded.ToString() + " X";
        }
        else if(itemName == "Rope"){
            if(ropeNeeded >= 0){
                ropeNeeded--;
            }
            else{
                ropeNeeded = 0;
                ropeButton.interactable = false;
            }
            menuRopeText.text = ropeNeeded.ToString() + " X";
        }
        else if(itemName == "Rock"){
            if(rockNeeded >= 0){
                rockNeeded--;
            }
            else{
                rockNeeded = 0;
                rockButton.interactable = false;
            }
            menuRockText.text = rockNeeded.ToString() + " X";
        }  
        RepairButtonInteractable();  
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

    public void ChangeModel(int childValPrev, int childValNew, bool activePre, bool activeNew){
        interchangableModel.transform.GetChild(childValPrev).gameObject.SetActive(activePre);
        interchangableModel.transform.GetChild(childValNew).gameObject.SetActive(activeNew);
    }

    private IEnumerator BoatTransition(bool called){
        Menu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fadingAnim.Play("Base Layer.FadeOut", 0, 0);
        yield return new WaitForSeconds(3f);
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        called = false;
    }

    private IEnumerator BoatWait(int waitChildValPrev, int waitChildValNew, bool waitActivePre, bool waitActiveNew){
        yield return new WaitForSeconds(2.3f);
        ChangeModel(waitChildValPrev, waitChildValNew, waitActivePre, waitActiveNew);
    }
}
