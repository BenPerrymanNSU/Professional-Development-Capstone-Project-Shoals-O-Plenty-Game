using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishingFunctionScript : MonoBehaviour
{
    public Image Menu;
    public Image Reticle;
    public Button yesButton;
    public Button noButton;

    public void ScriptFunction(bool called){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        if (called == true){
            Menu.gameObject.SetActive(true);
            Reticle.gameObject.SetActive(false);
            CameraController.GetComponent<PlayerPOV>().enabled = false;
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
            called = false;
        }
        
    }

    public void YesButton(bool called){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void NoButton(bool called){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Menu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        called = false;
    }
}
