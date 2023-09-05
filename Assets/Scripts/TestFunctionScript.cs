using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFunctionScript : MonoBehaviour
{
    bool called = false;

    void FixedUpdate(){
        Invoke("TestCall", 0f);
    }

    void TestCall(){
        Debug.Log("Hello!!!!");
        called = true;
    }
}
