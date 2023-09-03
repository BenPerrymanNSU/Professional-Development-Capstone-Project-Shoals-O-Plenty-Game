using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommands : MonoBehaviour
{
    private KeyCode[] commandKeys;


    void Start()
    {
        commandKeys = new KeyCode[] { KeyCode.E, KeyCode.I };
    }

    void FixedUpdate()
    {  
        for (int i = 0; i < commandKeys.Length; i++){
            var ckey = commandKeys[i];
            if (Input.GetKey(ckey)) {
                if (ckey == KeyCode.E){
                    
                }
            }
        }
    }
}
