using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class InvScript_DynamicDisplay : InvScript_UIDisplay
{
    [SerializeField] protected InvScript_UI slotPrefab;

    protected override void Start(){
        InvItemContainer.OnDynamicInventoryDisplayRequested += RefreshDynamicInventory;
        base.Start();

        AssignSlot(invDisSystem);
    }

    private void OnDestroy(){
        InvItemContainer.OnDynamicInventoryDisplayRequested -= RefreshDynamicInventory;
    }

    public void RefreshDynamicInv(InvItemSystem invToDisplay){
        invDisSystem = invToDisplay;
    }

    public override void AssignSlot(InvItemSystem invToDisplay){
        ClearSlots();
        invDisSlotDict = new Dictionary<InvScript_UI, InvItemSlot>();
        if(invToDisplay == null) return;

        for(int i = 0; i < invToDisplay.invSize; i++){
            var uiSlot = Instantiate(slotPrefab, transform);
            invDisSlotDict.Add(uiSlot, invToDisplay.InvLSlots[i]);
            uiSlot.InSlot(invToDisplay.InvLSlots[i]);
            uiSlot.UpdateUISlot();
        }
    }

    private void ClearSlots(){
        foreach(var item in transform.Cast<Transform>()){
            Destroy(item.gameObject);
        }

        if(invDisSlotDict != null) invDisSlotDict.Clear();
    }
}
*/