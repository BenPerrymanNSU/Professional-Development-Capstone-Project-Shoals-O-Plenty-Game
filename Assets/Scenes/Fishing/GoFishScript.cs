using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFishScript : MonoBehaviour
{
    public GameObject fishingUI;
    public GameObject fishingKey0;
    public GameObject fishingKey1;
    public GameObject fishingKey2;
    public GameObject fishingKey3;
    public GameObject fishingKey4;
    public GameObject fishingKey5;
    public GameObject fishingKey6;
    public GameObject fishingKey7;
    public GameObject fishingKey8;
    public GameObject fishingKey9;
    public GameObject ellipsis1;
    public GameObject ellipsis2;
    public GameObject ellipsis3;
    public GameObject Line;
    public GameObject Bobber;

    public void GoFish(){
        Line.SetActive(true);
        Bobber.SetActive(true);
        StartCoroutine(Ellipsis());
    }

    private IEnumerator Ellipsis(){
        ellipsis1.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ellipsis2.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ellipsis3.SetActive(true);
        Invoke("FindFish", 1.5f);
    }

    private void FindFish(){
        var fishPercentage = 0.50f;
        var resourcePercentage = 0.35f;

        ellipsis1.SetActive(false);
        ellipsis2.SetActive(false);
        ellipsis3.SetActive(false);

        if(Random.value < fishPercentage){
            fishingUI.SetActive(true);
            fishingKey0.SetActive(true);
            fishingKey1.SetActive(true);
            fishingKey2.SetActive(true);
            fishingKey3.SetActive(true);
            fishingKey4.SetActive(true);
            fishingKey5.SetActive(true);
            fishingKey6.SetActive(true);
            fishingKey7.SetActive(true);
            fishingKey8.SetActive(true);
            fishingKey9.SetActive(true);
            Debug.Log("Fish");
        }
        else if(Random.value < resourcePercentage){
            fishingUI.SetActive(true);
            fishingKey0.SetActive(true);
            fishingKey1.SetActive(true);
            fishingKey2.SetActive(true);
            fishingKey3.SetActive(true);
            fishingKey4.SetActive(true);
            fishingKey5.SetActive(true);
            fishingKey6.SetActive(true);
            fishingKey7.SetActive(true);
            fishingKey8.SetActive(true);
            fishingKey9.SetActive(true);
            Debug.Log("Rock");
        }
        else{
            Debug.Log("Nothin");
        }
    }
}
