using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InvScript_UIDisplay : MonoBehaviour
{
    /*
    [SerializeField] MouseData mouseInvItem;
    protected InvItemSystem invDisSystem;
    protected Dictionary<InvScript_UI, InvItemSlot> invDisSlotDict;
    public InvItemSystem invDisSystem2 => invDisSystem;
    public Dictionary<InvScript_UI, InvItemSlot> invDisSlotDict2 => invDisSlotDict;
    public abstract void AssignSlot(InvItemSystem invToDisplay);
    protected virtual void UpdateSlot(InvItemSystem updatedSlot){
        foreach(var slot in invDisSlotDict2){
            if(slot.Value == updatedSlot){
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }
    */
    public void SlotClicked(InvScript_UI clickedSlot){
        Debug.Log("Slot clicked");
    }
    
}
