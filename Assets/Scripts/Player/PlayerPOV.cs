using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPOV : MonoBehaviour
{
    public Transform playerPOV;
    private float cursorSensitivity = 5f;
    private float xClamp = 0;
    
    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float cursorX = Input.GetAxisRaw("Mouse X");
        float cursorY = Input.GetAxisRaw("Mouse Y");
        float rotationX = cursorX * cursorSensitivity;
        float rotationY = cursorY * cursorSensitivity;

        xClamp -= rotationY;

        Vector3 rotationPlayerPOV = playerPOV.transform.rotation.eulerAngles;
        rotationPlayerPOV.x -= rotationY;
        rotationPlayerPOV.z = 0;
        rotationPlayerPOV.y += rotationX;

        if (xClamp > 90){
            xClamp = 90;
            rotationPlayerPOV.x = 90;
        }
        else if (xClamp < -90){
            xClamp = -90;
            rotationPlayerPOV.x = 270;
        }

        playerPOV.rotation = Quaternion.Euler (rotationPlayerPOV);
    }
}
