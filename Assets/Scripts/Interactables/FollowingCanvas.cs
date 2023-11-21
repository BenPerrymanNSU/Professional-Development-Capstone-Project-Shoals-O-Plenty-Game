using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class FollowingCanvas : MonoBehaviour
{
    public Canvas worldCanvas;
    public GameObject canvasFocus;
    public Slider worldWaterSlider;
    public Slider worldCookSlider;

    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - canvasFocus.transform.position);
    }

    public void WaterSliderEnabled(){
        worldWaterSlider.gameObject.SetActive(true);
    }

    public void CookSliderEnabled(){
        worldCookSlider.gameObject.SetActive(true);
    }

    public void WaterSliderUpdater(int sliderAmount){
        worldWaterSlider.value -= sliderAmount;
    }

    public void CookSliderUpdater(int sliderAmount){
        worldCookSlider.value -= sliderAmount;
    }

    public void CallDisableCoroutine(int whichSlider){
        StartCoroutine(DisableSliders(whichSlider));
    }

    private IEnumerator DisableSliders(int worldSlider){
        if(worldSlider == 1){
            worldCookSlider.gameObject.SetActive(false);
        }
        else if(worldSlider == 2){
            worldWaterSlider.gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(.1f);
    }
}
