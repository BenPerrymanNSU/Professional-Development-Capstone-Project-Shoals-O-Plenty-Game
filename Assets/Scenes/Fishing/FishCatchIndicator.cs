using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCatchIndicator : MonoBehaviour
{
    public FishCollision grabPercent;
    public GameObject Indicater1;
    public GameObject Indicater2;
    public GameObject Indicater3;
    public GameObject Indicater4;
    public float Percent;

    void Update(){
        Percent = grabPercent.fishCatchPercentage;

        if(Percent <= 0.10f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.20f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.30f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.40f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.50f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.red;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.60f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.70f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else if(Percent <= 0.80f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else if(Percent <= 0.90f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.green;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(Percent == 1.00f){
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.white;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.white;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.white;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else{
            Indicater1.GetComponent<MeshRenderer>().material.color = Color.blue;
            Indicater2.GetComponent<MeshRenderer>().material.color = Color.blue;
            Indicater3.GetComponent<MeshRenderer>().material.color = Color.blue;
            Indicater4.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
