using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBobberController : MonoBehaviour
{
    public Animator PlayerBobberMover;
    private bool upBobber = false;
    private bool downBobber = false;
    private bool midBobber = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            if (upBobber == false && midBobber == true){
                PlayerBobberMover.SetBool("ReturntoMid", false);
                PlayerBobberMover.SetBool("PlayerUp", true);
                upBobber = true;
                midBobber = false;
            }

            else if (downBobber == true){
                PlayerBobberMover.SetBool("ReturntoMid", true);
                PlayerBobberMover.SetBool("PlayerDown", false);
                downBobber = false;
                midBobber = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            if (downBobber == false && midBobber == true){
                PlayerBobberMover.SetBool("ReturntoMid", false);
                PlayerBobberMover.SetBool("PlayerDown", true);
                downBobber = true;
                midBobber = false;
            }
            else if (upBobber == true){
                PlayerBobberMover.SetBool("ReturntoMid", true);
                PlayerBobberMover.SetBool("PlayerUp", false);
                upBobber = false;
                midBobber = true;
            }
        }
    }
}
