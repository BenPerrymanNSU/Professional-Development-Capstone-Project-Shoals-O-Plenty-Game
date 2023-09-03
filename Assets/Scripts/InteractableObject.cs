using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public MeshRenderer mesh;

    void OnTriggerEnter(Collider col){
        if (col.tag == "InteractableUI"){
            mesh.enabled = true;
        }
    }

    void OnTriggerExit(Collider col){
        if (col.tag == "InteractableUI"){
            mesh.enabled = false;
        }
    }
}
