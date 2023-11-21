using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InvItemContainer : MonoBehaviour
{
    [SerializeField] private int invContainerSize;
    [SerializeField] protected InvItemSystem invSystem;
    private static bool firstContainerActivation;
    public InvItemSystem InvSystem2 => invSystem;
    public static InvItemSystem tempInv;
    public static UnityAction<InvItemSystem> OnInvDisplayRequest;

    public bool fish0;
    public bool fish1;
    public bool fish2;
    public bool fish3;
    public bool fish4;
    public bool fish5;
    public bool fish6;
    public bool fish7;
    public bool fish8;
    public bool material9;
    public bool material10;
    public bool material11;

    private void Awake(){
        if(firstContainerActivation == false){
            invSystem = new InvItemSystem(invContainerSize);
            firstContainerActivation = true;
        }
        else{
            invSystem = new InvItemSystem(invContainerSize);
            StartCoroutine(InventoryApplicator());
        }
    }

    public void CheckInv(){
        fish0 = false;
        fish1 = false;
        fish2 = false;
        fish3 = false;
        fish4 = false;
        fish5 = false;
        fish6 = false;
        fish7 = false;
        fish8 = false;
        material9 = false;
        material10 = false;
        material11 = false;
        for(int i = 0; i < invSystem.InvLSlots.Count; i++){
            HasInSlot(invSystem.InvLSlots[i].itemData2);
        }
    }

    public void HasInSlot(InvItemData slotItemData){
        if(slotItemData != null){
            if(slotItemData.itemType == "Fish"){
                switch(slotItemData.itemID){
                    case 8:
                        if(fish8 == false){
                            fish8 = true;
                        }
                        break;
                    case 7:
                        if(fish7 == false){
                            fish7 = true;
                        }
                        break;
                    case 6:
                        if(fish6 == false){
                            fish6 = true;
                        }
                        break;
                    case 5:
                        if(fish5 == false){
                            fish5 = true;
                        }
                        break;
                    case 4:
                        if(fish4 == false){
                            fish4 = true;
                        }
                        break;
                    case 3:
                        if(fish3 == false){
                            fish3 = true;
                        }
                        break;
                    case 2:
                        if(fish2 == false){
                            fish2 = true;
                        }
                        break;
                    case 1:
                        if(fish1 == false){
                            fish1 = true;
                        }
                        break;
                    case 0:
                        if(fish0 == false){
                            fish0 = true;
                        }
                        break;
                    default:
                        Debug.Log("Something went wrong");
                        break;
                }
            }
            if(slotItemData.itemType == "Material"){
                switch(slotItemData.itemID){
                    case 9:
                        if(material9 == false){
                            material9 = true;
                        }
                        break;
                    case 10:
                        if(material10 == false){
                            material10 = true;
                        }
                        break;
                    case 11:
                        if(material11 == false){
                            material11 = true;
                        }
                        break;
                    default:
                        Debug.Log("Something went wrong");
                        break;
                }
            }
        }
    }

    public void MakeNewInv(){
        invSystem = new InvItemSystem(invContainerSize);
    }

    public IEnumerator InventoryApplicator(){
        for(int i = 0; i < invSystem.InvLSlots.Count; i++){
            if(invSystem.InvLSlots[i].itemData2 == null){
                if (firstContainerActivation == false) yield break;
                if (tempInv.InvLSlots[i] == null) yield break;
                invSystem.AddToInvSlot(tempInv.InvLSlots[i].itemData2, tempInv.InvLSlots[i].itemStackSize2);
            }
        }
    }

    void OnDestroy(){
        tempInv = invSystem;
    }
}
