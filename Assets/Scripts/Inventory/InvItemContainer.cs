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

    private void Awake(){
        if(firstContainerActivation == false){
            invSystem = new InvItemSystem(invContainerSize);
            firstContainerActivation = true;
        }
        else{
            invSystem = tempInv;
        }
    }

    void OnDestroy(){
        tempInv = invSystem;
    }
}
