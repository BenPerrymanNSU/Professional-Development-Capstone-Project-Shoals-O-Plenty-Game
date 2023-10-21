using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public abstract class InvScript_UIDisplay : MonoBehaviour
{
    [SerializeField] MouseData mouseInvItem;
    protected InvItemSystem invDisSystem;
    protected Dictionary<InvScript_UI, InvItemSlot> invDisSlotDict;
    public InvItemSystem invDisSystem2 => invDisSystem;
    public Dictionary<InvScript_UI, InvItemSlot> invDisSlotDict2 => invDisSlotDict;
    protected virtual void Start(){

    }
    public abstract void AssignSlot(InvItemSystem invToDisplay);
    protected virtual void UpdateSlot(InvItemSlot updatedSlot){
        foreach(var slot in invDisSlotDict2){
            if(slot.Value == updatedSlot){
                slot.Key.UpdateUISlot(updatedSlot);
            }
        }
    }

    public void SlotClicked(InvScript_UI clickedUISlot){
        bool shiftKeyPressed = Keyboard.current.leftShiftKey.isPressed;

        if(clickedUISlot.assignedUISlot.itemData2 != null && mouseInvItem.mouseInvSlot.itemData2 == null){
            if(shiftKeyPressed && clickedUISlot.assignedUISlot.SeverStack(out InvItemSlot halfStackSlot)){
                mouseInvItem.UpdateMouseInvSlot(halfStackSlot);
                clickedUISlot.UpdateUISlot();
                return;
            }
            else{
                mouseInvItem.UpdateMouseInvSlot(clickedUISlot.assignedUISlot);
                clickedUISlot.EmptyUISlot();
                return;
            }
        }

        if(clickedUISlot.assignedUISlot.itemData2 == null && mouseInvItem.mouseInvSlot.itemData2 != null){
            clickedUISlot.assignedUISlot.AssignSlotItem(mouseInvItem.mouseInvSlot);
            clickedUISlot.UpdateUISlot();

            mouseInvItem.EmptyMouseSlot();
            return;
        }

        if(clickedUISlot.assignedUISlot.itemData2 != null && mouseInvItem.mouseInvSlot.itemData2 != null){
            bool sameFish = clickedUISlot.assignedUISlot.itemData2 == mouseInvItem.mouseInvSlot.itemData2;
            if(sameFish && clickedUISlot.assignedUISlot.RemainingItemStackSpace(mouseInvItem.mouseInvSlot.itemStackSize2)){
                clickedUISlot.assignedUISlot.AssignSlotItem(mouseInvItem.mouseInvSlot);
                clickedUISlot.UpdateUISlot();
                mouseInvItem.EmptyMouseSlot();
                return;
            }
            else if(sameFish && !clickedUISlot.assignedUISlot.RemainingItemStackSpace(mouseInvItem.mouseInvSlot.itemStackSize2, out int leftoverItemStack)){
                if(leftoverItemStack < 1){
                    RearrangeSlots(clickedUISlot);
                }
                else{
                    int leftoverMouseStack = mouseInvItem.mouseInvSlot.itemStackSize2 - leftoverItemStack;
                    clickedUISlot.assignedUISlot.PropagateItemStack(leftoverItemStack);
                    clickedUISlot.UpdateUISlot();

                    var newItem = new InvItemSlot(mouseInvItem.mouseInvSlot.itemData2, leftoverMouseStack);
                    mouseInvItem.EmptyMouseSlot();
                    mouseInvItem.UpdateMouseInvSlot(newItem);
                    return;
                }
            }
            else if(!sameFish){
                RearrangeSlots(clickedUISlot);
                return;
            }
        }
    }

    private void RearrangeSlots(InvScript_UI clickedUISlot){
        var slotClone = new InvItemSlot(mouseInvItem.mouseInvSlot.itemData2, mouseInvItem.mouseInvSlot.itemStackSize2);
        mouseInvItem.EmptyMouseSlot();
        mouseInvItem.UpdateMouseInvSlot(clickedUISlot.assignedUISlot);
        clickedUISlot.EmptyUISlot();

        clickedUISlot.assignedUISlot.AssignSlotItem(slotClone);
        clickedUISlot.UpdateUISlot();
    }
    
}
