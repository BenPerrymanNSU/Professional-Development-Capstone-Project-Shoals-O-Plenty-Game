using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject iconFocus;
    private bool isLooking = false;

    void Start(){
        sprite.enabled = false;
        isLooking = false;
    }

    void OnTriggerEnter(Collider col){
        if (col.tag == "InteractableUI"){
            sprite.enabled = true;
            isLooking = true;

        }
    }

    void OnTriggerExit(Collider col){
        if (col.tag == "InteractableUI"){
            sprite.enabled = false;
            isLooking = false;
        }
    }

    void Update(){
        if (isLooking == true){
            transform.rotation = Quaternion.LookRotation(transform.position - iconFocus.transform.position);
        }
    }
}
