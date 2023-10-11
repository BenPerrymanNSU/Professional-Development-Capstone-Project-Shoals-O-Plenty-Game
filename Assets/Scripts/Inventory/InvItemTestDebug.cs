using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InvItemTestDebug : MonoBehaviour
{
    private InvItemData itemDataDebug;
    public GameObject container;
    private KeyCode[] commandKeys;

    void Start()
    {
        commandKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};
    }

    void FixedUpdate(){  
        var inventory = container.GetComponent<InvItemContainer>();

        for (int i = 0; i < commandKeys.Length; i++){
            var ckey = commandKeys[i];
            if (Input.GetKey(ckey)) {
                if (ckey == KeyCode.Alpha1){
                    itemDataDebug = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/BasicTestItem.asset");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){

                    }
                }
                else if (ckey == KeyCode.Alpha2){
                    itemDataDebug = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/BasicTestItem2.asset");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 1)){

                    }
                }
                else if (ckey == KeyCode.Alpha3){
                    itemDataDebug = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/BasicTestItem.asset");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 99)){

                    }
                }
                else if (ckey == KeyCode.Alpha4){
                    itemDataDebug = AssetDatabase.LoadAssetAtPath<InvItemData>("Assets/ScriptedObjects/BasicTestItem2.asset");
                    if (!inventory) return;
                    if (inventory.InvSystem2.AddToInvSlot(itemDataDebug, 99)){
                        
                    }
                }
            }
        }
    }
}
