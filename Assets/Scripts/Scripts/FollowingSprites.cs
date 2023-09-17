using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingSprites : MonoBehaviour
{
    public SpriteRenderer sprite;
    public GameObject iconFocus;

    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - iconFocus.transform.position);
    }
}
