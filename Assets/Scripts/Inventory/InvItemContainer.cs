using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InvItemContainer : MonoBehaviour
{
    [SerializeField] private int invContainerSize;
    public static UnityAction<InvItemSystem> OnInvDisplayRequest;
    [SerializeField] protected InvItemSystem invSystem;
    public InvItemSystem InvSystem2 => invSystem;

    private void Awake(){
        invSystem = new InvItemSystem(invContainerSize);
    }
}
