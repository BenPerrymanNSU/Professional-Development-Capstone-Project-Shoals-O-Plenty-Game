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

    public void CallDisableCoroutine(){
        StartCoroutine(DisableSliders());
    }

    private IEnumerator DisableSliders(){
        worldCookSlider.gameObject.SetActive(false);
        worldWaterSlider.gameObject.SetActive(false);
        yield return new WaitForSeconds(.1f);
    }
}
