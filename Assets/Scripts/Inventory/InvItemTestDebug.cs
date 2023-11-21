using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItemTestDebug : MonoBehaviour
{
    private InvItemData itemDataDebug;
    public GameObject container;
    private KeyCode[] commandKeys;

    void Start()
    {
        commandKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9};
    }

    void FixedUpdate(){  
        var inventory = container.GetComponent<InvItemContainer>();

        for (int i = 0; i < commandKeys.Length; i++){
            var ckey = commandKeys[i];
            if (Input.GetKey(ckey)) {
                if (ckey == KeyCode.Alpha1){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Easy/Goldfish");
                    Debug.Log(itemDataDebug);
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){

                    }
                }
                else if (ckey == KeyCode.Alpha2){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Med/Barracuda");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){

                    }
                }
                else if (ckey == KeyCode.Alpha3){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Easy/Goldfish");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 99)){

                    }
                }
                else if (ckey == KeyCode.Alpha4){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Med/Barracuda");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 99)){
                        
                    }
                }
                else if (ckey == KeyCode.Alpha5){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Hard/Swordfish");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){
                        
                    }
                }
                else if (ckey == KeyCode.Alpha6){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Materials/WoodPlank");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){
                        
                    }
                }
                else if (ckey == KeyCode.Alpha7){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Materials/Rock");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){
                        
                    }
                }
                else if (ckey == KeyCode.Alpha8){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Materials/Rope");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){
                        
                    }
                }
                else if (ckey == KeyCode.Alpha9){
                    itemDataDebug = Resources.Load<InvItemData>("ScriptedObjects/Hard/Bluefin Tuna");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){
                        
                    }
                }
            }
        }
    }
}
