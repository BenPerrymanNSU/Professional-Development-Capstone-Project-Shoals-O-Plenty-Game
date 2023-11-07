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

    public InvItemSystem(int size){
        invSlots = new List<InvItemSlot>(size);

        for (int i = 0; i < size; i++){
            invSlots.Add(new InvItemSlot());
        }
    }

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

    public bool ItemsExist(InvItemData invItem, out List<InvItemSlot> slot){
        slot = InvLSlots.Where(i => i.itemData2 == invItem).ToList();
        return slot == null ? false : true;
    }

    public bool EmptySlotsAvailable(out InvItemSlot emptySlot){
        emptySlot = InvLSlots.FirstOrDefault(i => i.itemData2 == null);
        return emptySlot == null ? false : true;
    }

}
