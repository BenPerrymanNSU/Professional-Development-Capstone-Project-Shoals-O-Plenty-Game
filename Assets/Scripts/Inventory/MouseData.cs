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
    public PlayerNeedStats playerNStats;
    private int fishDiffMult;

    private void Awake(){
        menuSprite.color = Color.clear;
        itemCounter.text = "";
    }

    public void UpdateMouseInvSlot(InvItemSlot mouseSlot){
        mouseInvSlot.AssignSlotItem(mouseSlot);
        ConsumeMouseMultiplier(mouseSlot);
        menuSprite.sprite = mouseSlot.itemData2.itemIcon;
        itemCounter.text = mouseSlot.itemStackSize2.ToString();
        menuSprite.color = Color.white;
    }

    public void UpdateMouseInvSlotInfo(InvItemSlot mouseSlot){
        menuSprite.sprite = mouseSlot.itemData2.itemIcon;
        itemCounter.text = mouseSlot.itemStackSize2.ToString();
        menuSprite.color = Color.white;

    }

    public void ConsumeMouseMultiplier(InvItemSlot mouseSlot){
        if(mouseSlot.itemData2.itemDifficulty == "Easy"){
            fishDiffMult = 1;
        }
        else if(mouseSlot.itemData2.itemDifficulty == "Med"){
            fishDiffMult = 2;
        }
        else if(mouseSlot.itemData2.itemDifficulty == "Hard"){
            fishDiffMult = 3;
        }
        else{
            fishDiffMult = 1;
        }
    }

    public void Update(){
        if(mouseInvSlot.itemData2 != null){
            transform.position = Mouse.current.position.ReadValue();
            if(Mouse.current.leftButton.wasPressedThisFrame && !mouseOverUI()){
                EmptyMouseSlot();
            }
            if(Mouse.current.rightButton.wasPressedThisFrame && !mouseOverUI()){
                ConsumeMouseSlot();
            }
        }
    }

    public void ConsumeMouseSlot(){
        if(mouseInvSlot.itemData2.itemEdibility == true){
            if(mouseInvSlot.itemData2.itemRaw == true){
                var randomSickNum = Random.value;
                if(randomSickNum >= 0.85f){
                    if(mouseInvSlot.itemStackSize2 >= 1){
                        mouseInvSlot.ReduceItemStack(1);
                        UpdateMouseInvSlotInfo(mouseInvSlot);
                        playerNStats.Hunger = playerNStats.SubtractFromStat(playerNStats.hungerBar, playerNStats.Hunger, (5f) * fishDiffMult);
                        playerNStats.Thirst = playerNStats.SubtractFromStat(playerNStats.thirstBar, playerNStats.Thirst, (5f) * fishDiffMult);
                        playerNStats.Rest = playerNStats.SubtractFromStat(playerNStats.restBar, playerNStats.Rest, (5f) * fishDiffMult);
                    }
                    else{
                        EmptyMouseSlot();
                    }

                    if(mouseInvSlot.itemStackSize2 == 0){
                        EmptyMouseSlot();
                    }
                }
                else{
                    if(mouseInvSlot.itemStackSize2 >= 1){
                        mouseInvSlot.ReduceItemStack(1);
                        UpdateMouseInvSlotInfo(mouseInvSlot);
                        playerNStats.Hunger = playerNStats.AddToStat(playerNStats.hungerBar, playerNStats.Hunger, mouseInvSlot.itemData2.itemHungerSatiation);
                        playerNStats.Thirst = playerNStats.AddToStat(playerNStats.thirstBar, playerNStats.Thirst, mouseInvSlot.itemData2.itemThirstSatiation);
                    }
                    else{
                        EmptyMouseSlot();
                    }

                    if(mouseInvSlot.itemStackSize2 == 0){
                        EmptyMouseSlot();
                    }
                }
            }
            else{
                if(mouseInvSlot.itemStackSize2 >= 1){
                    mouseInvSlot.ReduceItemStack(1);
                    UpdateMouseInvSlotInfo(mouseInvSlot);
                    playerNStats.Hunger = playerNStats.AddToStat(playerNStats.hungerBar, playerNStats.Hunger, mouseInvSlot.itemData2.itemHungerSatiation);
                    playerNStats.Thirst = playerNStats.AddToStat(playerNStats.thirstBar, playerNStats.Thirst, mouseInvSlot.itemData2.itemThirstSatiation);
                }
                else{
                    EmptyMouseSlot();
                }

                if(mouseInvSlot.itemStackSize2 == 0){
                    EmptyMouseSlot();
                }
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
