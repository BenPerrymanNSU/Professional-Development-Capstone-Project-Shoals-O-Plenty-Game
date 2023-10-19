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
        CameraController.GetComponent<PlayerPOV>().enabled = false;
        CameraController.GetComponent<PlayerMovement>().enabled = false;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
    }

    public void RegainPlayerMovement(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CameraController.GetComponent<PlayerPOV>().enabled = true;
        CameraController.GetComponent<PlayerMovement>().enabled = true;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = true;
    }
}
