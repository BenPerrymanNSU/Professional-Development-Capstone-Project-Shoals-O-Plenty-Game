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

    private void Awake(){
        if(firstContainerActivation == false){
            invSystem = new InvItemSystem(invContainerSize);
            firstContainerActivation = true;
        }
        else{
            invSystem = tempInv;
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
                            Debug.Log(8);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 7:
                        if(fish7 == false){
                            fish7 = true;
                            Debug.Log(7);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 6:
                        if(fish6 == false){
                            fish6 = true;
                            Debug.Log(6);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 5:
                        if(fish5 == false){
                            fish5 = true;
                            Debug.Log(5);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 4:
                        if(fish4 == false){
                            fish4 = true;
                            Debug.Log(4);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 3:
                        if(fish3 == false){
                            fish3 = true;
                            Debug.Log(3);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 2:
                        if(fish2 == false){
                            fish2 = true;
                            Debug.Log(2);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 1:
                        if(fish1 == false){
                            fish1 = true;
                            Debug.Log(1);
                            Debug.Log(slotItemData);
                        }
                        break;
                    case 0:
                        if(fish0 == false){
                            fish0 = true;
                            Debug.Log(0);
                            Debug.Log(slotItemData);
                        }
                        break;
                    default:
                        Debug.Log("Something went wrong");
                        break;
                }
            }
        }
    }

    void OnDestroy(){
        tempInv = invSystem;
    }
}
