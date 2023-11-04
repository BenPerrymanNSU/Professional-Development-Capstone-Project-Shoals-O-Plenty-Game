using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PauseMenu : MonoBehaviour
{
    private GameObject CameraController;
    public GameObject sleepMenu;
    public SleepFunctionScript sleepFunc;
    public GameObject fishinMenu;
    public FishingFunctionScript fishFunc;
    public GameObject inventoryMenu;
    public PlayerCommands playerComs;
    //public Image campfireMenu;
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
            sleepFunc.ScriptFunction(false);
            sleepMenu.SetActive(false);
        }
        else if(fishinMenu.activeSelf == true){
            fishFunc.ScriptFunction(false);
            fishinMenu.SetActive(false);
        }
        else if(inventoryMenu.activeSelf == true){
            playerComs.InventoryOpen = false;
            playerComs.actionPerformed = false;
            playerComs.notInScene = false;
            inventoryMenu.SetActive(false);
        }

        Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.GetComponent<PlayerPOV>().enabled = false;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        Time.timeScale = 1;
        
    }
}
