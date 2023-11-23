using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InvItemSystem
{
    [SerializeField] private List<InvItemSlot> invSlots;
    public List<InvItemSlot> InvLSlots => invSlots;
    public int invSize => InvLSlots.Count;
    
    public UnityAction<InvItemSlot> OnInvSlotAlteration;

    // Creates a new inventory for the player to store items within.
    // New inventory List is then filled with inventory slots which 
    // can then be filled with scriptable item data.
    public InvItemSystem(int size){
        invSlots = new List<InvItemSlot>(size);

        for (int i = 0; i < size; i++){
            invSlots.Add(new InvItemSlot());
        }
    }

    // Returns true if the player's inventory is not full.
    // Checks to see if the player inventory has any remaining space for the
    // item it is trying to add. If the slot is empty it will add the item,
    // if the their is a pre-existing stack of items that is not full it will
    // add to that item stack first. Otherwise return false.
    public bool AddToInvSlot(InvItemData invItem, int invItemAmount){
        if (ItemsExist(invItem, out List<InvItemSlot> slot)){
            foreach(var space in slot){
                if(space.RemainingItemStackSpace(invItemAmount)){
                    space.PropagateItemStack(invItemAmount);
                    OnInvSlotAlteration?.Invoke(space);
                    return true;
                }
            }
        }
        
        if (EmptySlotsAvailable(out InvItemSlot emptySlot)){
            emptySlot.UpdateInvSlot(invItem, invItemAmount);
            OnInvSlotAlteration?.Invoke(emptySlot);
            return true;
        }

        return false;
    }

    // Checks to see if an item exists within an inventory slot and returns accordingly.
    public bool ItemsExist(InvItemData invItem, out List<InvItemSlot> slot){
        slot = InvLSlots.Where(i => i.itemData2 == invItem).ToList();
        return slot == null ? false : true;
    }

    // Returns true or false based on if there are empty inventory slots available for
    // an item to be place within.
    public bool EmptySlotsAvailable(out InvItemSlot emptySlot){
        emptySlot = InvLSlots.FirstOrDefault(i => i.itemData2 == null);
        return emptySlot == null ? false : true;
    }

}
