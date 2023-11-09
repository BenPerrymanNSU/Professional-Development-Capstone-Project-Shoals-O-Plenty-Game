using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BoatFunctionScript : MonoBehaviour
{
    public Image Menu;
    public Image Reticle;
    public Button noButton;
    //private bool ButtonClicked;

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

    public void YesButton(bool called){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
        Menu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
}
