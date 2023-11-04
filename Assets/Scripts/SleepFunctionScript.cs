using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SleepFunctionScript : MonoBehaviour
{
    public Image Menu;
    public Image Reticle;
    public Button yesButton;
    public Button noButton;
    public PlayerNeedStats playerNStats;
    public LightingSystem lightSystemCall;
    public Animator fadingAnim;
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
        StartCoroutine("Transition", 0f);
        playerNStats.Hunger = playerNStats.SubtractFromStat(playerNStats.hungerBar, playerNStats.Hunger, 30f);
        playerNStats.Thirst = playerNStats.SubtractFromStat(playerNStats.thirstBar, playerNStats.Thirst, 30f);
        playerNStats.Rest = playerNStats.AddToStat(playerNStats.restBar, playerNStats.Rest, 60f);
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
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

    private IEnumerator Transition(){
        fadingAnim.Play("Base Layer.FadeOut", 0, 0);
        yield return new WaitForSeconds(2.3f);
        LightingSystem.lightTime2 = lightSystemCall.lightTime;
        LightingSystem.lightTime2 += 22.5f; 
        lightSystemCall.lightAnim.Play("Base Layer.LightCycle", 0, LightingSystem.lightTime2);
    }
}
