using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PauseMenu : MonoBehaviour
{
    private GameObject CameraController;
    public GameObject pauseMenu;
    public GameObject sleepMenu;
    public SleepFunctionScript sleepFunc;
    public GameObject fishinMenu;
    public FishingFunctionScript fishFunc;
    public GameObject inventoryMenu;
    public CampfireFunctionScript campFunc;
    public GameObject campfireMenu;
    public GameObject cookMenu;
    public BoatFunctionScript boatFunc;
    public GameObject repairMenu;
    public PlayerCommands playerComs;
    private bool Paused = false;

    void Start(){
        CameraController = GameObject.Find("PlayerTestCamera");
        Invoke("ResumeGame", 0f);
    }

    void Update(){

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame(){
        
        if(sleepMenu.activeSelf == true){
            sleepFunc.NoButton(true);
        }
        else if(fishinMenu.activeSelf == true){
            fishFunc.NoButton(true);
        }
        else if(inventoryMenu.activeSelf == true){
            playerComs.InventoryOpen = false;
            playerComs.actionPerformed = false;
            playerComs.notInScene = false;
            inventoryMenu.SetActive(false);
        }
        else if(campfireMenu.activeSelf == true){
            campFunc.NoButton(true);
        }
        else if(cookMenu.activeSelf == true){
            campFunc.NoButton(true);
        }
        else if(repairMenu.activeSelf == true){
            boatFunc.NoButton(true);
        }

        Paused = true;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.GetComponent<PlayerPOV>().enabled = false;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        Paused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        Time.timeScale = 1;
        
    }

    private void OnDestroy(){
        Time.timeScale = 1;
    }
}
