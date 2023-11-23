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

    // Follows the player's location to face them at all times.
    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - canvasFocus.transform.position);
    }

    // Enables external boiling water slider graphic to allow the player to
    // walk around while still being able to view its progress from a distance.
    public void WaterSliderEnabled(){
        worldWaterSlider.gameObject.SetActive(true);
    }

    // Enables external cooking food slider graphic to allow the player to
    // walk around while still being able to view its progress from a distance.
    public void CookSliderEnabled(){
        worldCookSlider.gameObject.SetActive(true);
    }

    // Decreases the passed in slider's ID in accordance with the cooking/boiling
    // countdown.
    public void UpdateSlider(int sliderID, int sliderAmount){
        if(sliderID == 1){
            worldCookSlider.value -= sliderAmount;
        }
        else if(sliderID == 2){
            worldWaterSlider.value -= sliderAmount;
        }
    }

    // Calls coroutine to disable the passed in slider graphic ID.
    public void CallDisableCoroutine(int whichSlider){
        StartCoroutine(DisableSliders(whichSlider));
    }

    // disables the slider graphics associated with the ID.
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
