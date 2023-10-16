using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    private KeyCode[] commandKeys;
    public GameObject interactableObjectIcon = null;
    public GameObject InventoryMenu;
    private GameObject cameraMan;
    public string ScriptName;
    private string ComponentName;
    private bool actionPerformed = false;
    private bool InventoryOpen = false;


    void Start()
    {
        commandKeys = new KeyCode[] { KeyCode.E, KeyCode.I };
        cameraMan = GameObject.Find("PlayerTestCamera");
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

                if(ckey == KeyCode.I && InventoryOpen == false && actionPerformed == false){
                    InventoryMenu.SetActive(true);
                    InventoryOpen = true;
                    cameraMan.GetComponent<PlayerPOV>().enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    actionPerformed = true;
                    Invoke("CommandCoolDown", 0.5f);
                }
                else if(ckey == KeyCode.I && InventoryOpen == true && actionPerformed == false){
                    InventoryMenu.SetActive(false);
                    InventoryOpen = false;
                    cameraMan.GetComponent<PlayerPOV>().enabled = true;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    actionPerformed = true;
                    Invoke("CommandCoolDown", 0.5f);
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
