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

    void ScriptFunction(bool called){
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
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Menu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine("Transition", 0f);
        playerNStats.Hunger = playerNStats.SubtractFromStat(playerNStats.Hunger, 30f);
        playerNStats.Thirst = playerNStats.SubtractFromStat(playerNStats.Thirst, 30f);
        playerNStats.Rest = playerNStats.AddToStat(playerNStats.Rest, 60f);
        playerNStats.SubtractFromStatBar(playerNStats.hungerBar, 30f);
        playerNStats.SubtractFromStatBar(playerNStats.thirstBar, 30f);
        playerNStats.AddToStatBar(playerNStats.restBar, 60f);
        playerNStats.statHungerTracker = playerNStats.AddToTracker(playerNStats.statHungerTracker, 30f);
        playerNStats.statThirstTracker = playerNStats.AddToTracker(playerNStats.statThirstTracker, 30f);
        playerNStats.statRestTracker = playerNStats.SubtractFromTracker(playerNStats.statRestTracker, 60f);
        CameraController.GetComponent<PlayerPOV>().enabled = true;
    }

    public void NoButton(bool called){
        Menu.gameObject.SetActive(false);
        Reticle.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        CameraController.GetComponent<PlayerPOV>().enabled = true;
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
