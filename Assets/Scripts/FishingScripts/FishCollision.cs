using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    public Text fishPercentageText;
    public GameObject bobberIndicater;
    public float fishCatchPercentage = 0.00f;
    public float fishCatchNum = 0.00f;
    public bool fishFound = false;

    void Update(){
        fishPercentageText.text = (Mathf.Round(fishCatchPercentage * 100)).ToString() + "%";

        if(fishCatchPercentage < 0.00f){
            fishCatchPercentage = 0.00f;
        }
        else if(fishCatchPercentage > 1.00f){
            fishCatchPercentage = 1.00f;
        }

        if(fishFound == true){
            bobberIndicater.GetComponent<MeshRenderer>().material.color = Color.green;
            if(Input.GetKeyDown(KeyCode.Space)){
                fishCatchPercentage += fishCatchNum;
                fishFound = false;
            }
        }
        else{
            bobberIndicater.GetComponent<MeshRenderer>().material.color = Color.red;
            if(Input.GetKeyDown(KeyCode.Space)){
                fishCatchPercentage -= 0.10f;
            }
        }
    }

    void OnTriggerEnter(Collider col){
        if (col.tag == "GoodFish"){
            fishFound = true;         
            fishCatchNum = 0.10f;
        }

        else if (col.tag == "BadFish"){
            fishFound = true; 
            fishCatchNum = -0.10f;
        }
    }

    void OnTriggerExit(Collider col){
        if (col.tag == "GoodFish"){
            fishFound = false;
            col.enabled = false;
        }
        else if (col.tag == "BadFish"){
            fishFound = false;
            col.enabled = false;
        }
    }
}
