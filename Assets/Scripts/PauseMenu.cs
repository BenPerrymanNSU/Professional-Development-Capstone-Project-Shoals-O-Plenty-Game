using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject CameraController;
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
        Time.timeScale = 0;
        
        Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.GetComponent<PlayerPOV>().enabled = false;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        //scoreText.gameObject.SetActive(false);
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
        //scoreText.gameObject.SetActive(true);
    }
}
