using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FishCollision : MonoBehaviour
{
    public Text fishPercentageText;
    public GameObject bobberIndicater;
    public AudioSource correctSound;
    public AudioSource incorrectSound;
    public float fishCatchPercentage = 0.00f;
    public float fishCatchNum = 0.00f;
    public bool fishFound = false;

    // Checks to see if the player's fish catch rate value has decreased or increase too much and
    // sets them to a min/max value. This also updates the fishing catch rate text displayed to the
    // player while the minigame is being played. Finally, this detects if the player is pressing the
    // space bar over a fish or has pressed it over nothing. The catch rate increases if its a fish
    // and decreases if the player misses.
    void Update(){
        if(fishCatchPercentage < 0.00f){
            fishCatchPercentage = 0.00f;
        }
        
        if(fishCatchPercentage > 1.00f){
            fishCatchPercentage = 1.00f;
        }

        fishPercentageText.text = (Mathf.Round(fishCatchPercentage * 100)).ToString() + "%";

        if(fishFound == true){
            bobberIndicater.GetComponent<MeshRenderer>().material.color = Color.green;
            if(Input.GetKeyDown(KeyCode.Space)){
                fishCatchPercentage += fishCatchNum;
                correctSound.Play();
                fishFound = false;
            }
        }
        else{
            bobberIndicater.GetComponent<MeshRenderer>().material.color = Color.red;
            if(Input.GetKeyDown(KeyCode.Space)){
                incorrectSound.Play();
                fishCatchPercentage -= 0.10f;
            }
        }
    }

    // Triggerbox attached to the player's bobber during the minigame detects
    // whether or not the fish token is a good or bad fish. Good fish increase the 
    // catch rate value, while bad ones decrease it.
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

    // Upon the fish tokens exiting the bobber's triggerbox it disables their
    // hitboxes to ensure the player cannot spam the space bar and get a ton
    // of free points.
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
