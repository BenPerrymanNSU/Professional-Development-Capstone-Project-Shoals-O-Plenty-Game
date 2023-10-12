using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    private KeyCode[] commandKeys;
    public GameObject interactableObjectIcon = null;
    public GameObject InventoryMenu;
    public string ScriptName;
    private string ComponentName;
    private bool actionPerformed = false;
    private bool InventoryOpen = false;


    void Start()
    {
        commandKeys = new KeyCode[] { KeyCode.E, KeyCode.I };
    }

    void FixedUpdate(){  
        for (int i = 0; i < commandKeys.Length; i++){
            var ckey = commandKeys[i];
            if (Input.GetKey(ckey)) {
                if (ckey == KeyCode.E){
                    if (interactableObjectIcon == null){
                        break;
                    }
                    else{
                        var function = interactableObjectIcon.GetComponent(ScriptName) as MonoBehaviour;
                        if(actionPerformed == false){
                            function.enabled = true;
                            function.SendMessage("ScriptFunction", true);
                            actionPerformed = true;
                        }
                        Invoke("CommandCoolDown", 1f);
                    }
                }
                else if(ckey == KeyCode.I && InventoryOpen == false){
                        if(actionPerformed == false){
                            InventoryOpen = true;
                            InventoryMenu.SetActive(true);
                            actionPerformed = true;
                        }
                        Invoke("CommandCoolDown", 1f);
                }
                else if(ckey == KeyCode.I && InventoryOpen == true){
                        if(actionPerformed == false){
                            InventoryOpen = false;
                            InventoryMenu.SetActive(false);
                            actionPerformed = true;
                        }
                        Invoke("CommandCoolDown", 1f);
                }
            }
        }
    }

    void CommandCoolDown(){
        actionPerformed = false;
    }

    void OnTriggerEnter(Collider col){
        if (col.tag == "ObjectOfInterest"){
            interactableObjectIcon = col.gameObject;
            Component[] components = interactableObjectIcon.GetComponents(typeof(Component));
            foreach(Component component in components){
                ComponentName = component.ToString();
                if(ComponentName.Contains("Function")){
                    ScriptName = ComponentName.Split('(', ')')[1];
                }
                else{
                    ComponentName = null;
                    ScriptName = null;
                }
            }
        }
    }

    void OnTriggerExit(Collider col){
        if (col.tag == "ObjectOfInterest"){
            var function = interactableObjectIcon.GetComponent(ScriptName) as MonoBehaviour;
            interactableObjectIcon = null;
            ComponentName = null;
            ScriptName = null;
            function.enabled = false;
        }
    }

}
