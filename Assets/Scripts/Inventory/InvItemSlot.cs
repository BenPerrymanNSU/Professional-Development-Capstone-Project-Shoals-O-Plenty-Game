using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InvItemSlot
{
    [SerializeField] private InvItemData itemData;
    [SerializeField] private int itemStackSize;

    public InvItemData itemData2 => itemData;
    public int itemStackSize2 => itemStackSize;

    public InvItemSlot(InvItemData itemSource, int itemAmount){
        itemData = itemSource;
        itemStackSize = itemAmount;
    }

    public InvItemSlot(){
        EmptyItemSlot();
    }

    public void UpdateInvSlot(InvItemData data, int itemAmount){
        itemData = data;
        itemStackSize = itemAmount;
    }

    public bool RemainingItemStackSpace(int itemAmountToProp, out int itemAmountSpaceLeft){
        itemAmountSpaceLeft = itemData2.itemStackablility - itemStackSize;
        return RemainingItemStackSpace(itemAmountToProp);
    }

    public bool RemainingItemStackSpace(int itemAmountToProp){
        if (itemStackSize + itemAmountToProp <= itemData.itemStackablility){
            return true;
        }
        else{
            return false;
        }
    }

    public void PropagateItemStack(int itemAmount){
        itemStackSize += itemAmount;
    }

    public void ReduceItemStack(int itemAmount){
        itemStackSize -= itemAmount;
    }

    public void EmptyItemSlot(){
        itemData = null;
        itemStackSize = -1; 
    }
}
