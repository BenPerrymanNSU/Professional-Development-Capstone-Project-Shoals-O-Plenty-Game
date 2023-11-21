using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PauseMenuFishing : MonoBehaviour
{
    private GameObject CameraController;
    public GameObject pauseMenu;
    public GameObject inventoryMenu;
    public PlayerCommands playerComs;
    public Button exitButton;
    public Button fishButton;
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
        exitButton.interactable = false;
        fishButton.interactable = false;
        if(inventoryMenu.activeSelf == true){
            playerComs.InventoryOpen = false;
            playerComs.actionPerformed = false;
            playerComs.notInScene = false;
            inventoryMenu.SetActive(false);
        }

        Paused = true;
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        Time.timeScale = 0;
    }

    public void ResumeGame(){
        Paused = false;
        pauseMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        exitButton.interactable = true;
        fishButton.interactable = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        Time.timeScale = 1;
    }

    private void OnDestroy(){
        Time.timeScale = 1;
    }

}
