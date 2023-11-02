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
            POV.enabled = false;
        }
        if(CameraController.TryGetComponent<PlayerMovement>(out PlayerMovement PM)){
            PM.enabled = false;
        }
        if(CameraController.TryGetComponent<PlayerCommands>(out PlayerCommands PC)){
            PC.enabled = false;
        }
    }

    public void RegainPlayerMovement(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(CameraController.TryGetComponent<PlayerPOV>(out PlayerPOV POV)){
            POV.enabled = true;
        }
        if(CameraController.TryGetComponent<PlayerMovement>(out PlayerMovement PM)){
            PM.enabled = true;
        }
        if(CameraController.TryGetComponent<PlayerCommands>(out PlayerCommands PC)){
            PC.enabled = true;
        }
    }

    public void RegainPlayerMovementFishing(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        if(CameraController.TryGetComponent<PlayerCommands>(out PlayerCommands PC)){
            PC.enabled = true;
        }
    }
}
