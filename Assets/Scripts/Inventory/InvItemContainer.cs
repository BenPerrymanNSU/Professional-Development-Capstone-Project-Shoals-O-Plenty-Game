using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InvItemContainer : MonoBehaviour
{
    [SerializeField] private int invContainerSize;
    [SerializeField] protected InvItemSystem invSystem;

    public InvItemSystem InvSystem2 => invSystem;

    public static UnityAction<InvItemSystem> OnInvDisplayRequest;

    private void Awake(){
        invSystem = new InvItemSystem(invContainerSize);
    }
}
