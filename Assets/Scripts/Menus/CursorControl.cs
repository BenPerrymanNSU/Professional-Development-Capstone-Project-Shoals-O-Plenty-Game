using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{

    void Start(){
        GameObject CameraController = GameObject.Find("PlayerTestCamera");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        CameraController.GetComponent<PlayerPOV>().enabled = false;
        CameraController.GetComponent<PlayerMovement>().enabled = false;
        CameraController.GetComponentInChildren<PlayerCommands>().enabled = false;
    }
}
