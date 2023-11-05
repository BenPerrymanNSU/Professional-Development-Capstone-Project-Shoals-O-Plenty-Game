using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FollowingCanvas : MonoBehaviour
{
    public Canvas worldCanvas;
    public GameObject canvasFocus;
    public Slider worldWaterSlider;

    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - canvasFocus.transform.position);
    }

    public void SliderUpdater(int sliderAmount){
        worldWaterSlider.value -= sliderAmount;
    }

}
