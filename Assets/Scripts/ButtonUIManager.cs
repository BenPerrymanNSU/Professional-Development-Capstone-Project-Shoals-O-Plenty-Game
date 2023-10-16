/*
    ButtonUIManager.cs controls the buttons that transition scenes
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonUIManager : MonoBehaviour
{
    // moves to next scene in build index list
    public void SceneForward(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // loads scene 0, the main menu
    public void SceneReturn(){
        Debug.Log("fwtessafde");
        SceneManager.LoadScene(0);
    }

    // closes unity editor play view 
    public void Exit(){
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
