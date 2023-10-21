using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MouseData : MonoBehaviour
{
    public Image menuSprite;
    public TextMeshProUGUI itemCounter;
    public InvItemSlot mouseInvSlot;

    private void Awake(){
        menuSprite.color = Color.clear;
        itemCounter.text = "";
    }

    public void UpdateMouseInvSlot(InvItemSlot mouseSlot){
        mouseInvSlot.AssignSlotItem(mouseSlot);
        menuSprite.sprite = mouseSlot.itemData2.itemIcon;
        itemCounter.text = mouseSlot.itemStackSize2.ToString();
        menuSprite.color = Color.white;
    }

    public void Update(){
        if(mouseInvSlot.itemData2 != null){
            transform.position = Mouse.current.position.ReadValue();
            if(Mouse.current.leftButton.wasPressedThisFrame && !mouseOverUI()){
                EmptyMouseSlot();
            }
        }
    }

    public void EmptyMouseSlot(){
        mouseInvSlot.EmptyItemSlot();
        menuSprite.color = Color.clear;
        itemCounter.text = "";
        menuSprite.sprite = null;
        
    }

    public static bool mouseOverUI(){
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
