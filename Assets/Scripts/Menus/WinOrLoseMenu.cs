using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class WinOrLoseMenu : MonoBehaviour
{
    public Image Background;
    public TextMeshProUGUI menuText;
    public WinOrLoseScript gameState;
    public InvItemContainer playerInvCon;
    public bool finalState;

    void Awake(){
        finalState = gameState.State2;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        if(finalState == true){
            if(Background != null && menuText != null){
                Background.color = Color.blue;
                menuText.text = "You Win!!!";
            }
            else{
                Debug.Log("Problem");
            }
        }
        playerInvCon.MakeNewInv();
        gameState.State2 = true;
    }
}
