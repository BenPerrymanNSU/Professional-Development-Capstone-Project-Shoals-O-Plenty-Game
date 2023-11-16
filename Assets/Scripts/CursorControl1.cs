using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl1 : MonoBehaviour
{
    public Animator fadeAnimator;

    public void RestrictPlayerMovement(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(CameraController.TryGetComponent<PlayerPOV>(out PlayerPOV POV)){
            Debug.Log("POV");
            POV.enabled = false;
        }
        if(CameraController.TryGetComponent<PlayerMovement>(out PlayerMovement PM)){
            Debug.Log("Move");
            PM.enabled = false;
        }
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
    }

    public void RegainPlayerMovement(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(CameraController.TryGetComponent<PlayerPOV>(out PlayerPOV POV)){
            Debug.Log("POV");
            POV.enabled = true;
        }
        if(CameraController.TryGetComponent<PlayerMovement>(out PlayerMovement PM)){
            Debug.Log("Move");
            PM.enabled = true;
        }
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
    }

    public void RegainPlayerMovementFishing(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
    }
}
