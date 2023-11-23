using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinOrLoseScript : MonoBehaviour
{
    public static bool State;
    public bool State2;

    // Upon activation set bool to the static bool's value.
    public void Awake(){
        State2 = State;
    }

    // Sets static bool's value to the passed in value and loads the win/lose screen.
    public void WinOrLose(bool gameState){
        State = gameState;
        SceneManager.LoadScene(3);
    }
}
