using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvScript_StaticDisplay : InvScript_UIDisplay
{
    [SerializeField] private InvItemContainer invContainer;
    [SerializeField] private InvScript_UI[] slots;
    protected override void Start(){
        base.Start();
        if(invContainer != null){
            invDisSystem = invContainer.InvSystem2;
            invDisSystem.OnInvSlotAlteration += UpdateSlot;
        }
        else Debug.LogWarning($"Missing Inventory on {this.gameObject}");
        AssignSlot(invDisSystem);
    }

    public override void AssignSlot(InvItemSystem invToDisplay){
        invDisSlotDict = new Dictionary<InvScript_UI, InvItemSlot>();
        if (slots.Length != invDisSystem.invSize) Debug.Log($"Inventory slots no longer sync on {this.gameObject}");
        for(int i = 0; i < invDisSystem.invSize; i++){
            invDisSlotDict.Add(slots[i], invDisSystem.InvLSlots[i]);
            slots[i].InSlot(invDisSystem.InvLSlots[i]);
        }
    }
}
