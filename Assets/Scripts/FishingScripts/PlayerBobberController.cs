using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBobberController : MonoBehaviour
{
    public Animator PlayerBobberMover;
    public GameObject PlayerBobber;
    public bool upBobber = false;
    public bool downBobber = false;
    public bool midBobber = true;

    void Start(){
        PlayerBobberMover.keepAnimatorControllerStateOnDisable = false;
        PlayerBobber.transform.GetChild(3).gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            if (upBobber == false && midBobber == true){
                StartCoroutine(TriggerDisabler());
                PlayerBobberMover.SetBool("ReturntoMid", false);
                PlayerBobberMover.SetBool("PlayerUp", true);
                upBobber = true;
                midBobber = false;
            }

            else if (downBobber == true){
                StartCoroutine(TriggerDisabler());
                PlayerBobberMover.SetBool("ReturntoMid", true);
                PlayerBobberMover.SetBool("PlayerDown", false);
                downBobber = false;
                midBobber = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            if (downBobber == false && midBobber == true){
                StartCoroutine(TriggerDisabler());
                PlayerBobberMover.SetBool("ReturntoMid", false);
                PlayerBobberMover.SetBool("PlayerDown", true);
                downBobber = true;
                midBobber = false;
            }

            else if (upBobber == true){
                StartCoroutine(TriggerDisabler());
                PlayerBobberMover.SetBool("ReturntoMid", true);
                PlayerBobberMover.SetBool("PlayerUp", false);
                upBobber = false;
                midBobber = true;
            }
        }
    }
    
    private IEnumerator TriggerDisabler(){
        PlayerBobber.transform.GetChild(3).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        PlayerBobber.transform.GetChild(3).gameObject.SetActive(true);
        Invoke("killTriggerDisabler", 0f);
    }

    private void killTriggerDisabler(){
        StopCoroutine("TriggerDisabler");
    }
}
