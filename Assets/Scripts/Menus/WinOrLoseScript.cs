using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinOrLoseScript : MonoBehaviour
{
    public static bool State;
    public bool State2;

    public void Awake(){
        State2 = State;
    }

    public void WinOrLose(bool gameState){
        SceneManager.LoadScene(3);
        State = gameState;
    }
}
