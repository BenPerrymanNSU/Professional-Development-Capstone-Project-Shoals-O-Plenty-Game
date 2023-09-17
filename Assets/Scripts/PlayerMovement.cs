using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ThirdPersonCharacter character;
    public Animator animator;

    public float movementAcceleration;
    public float movementMaxSpeed = 10000;
    public Vector3 moveDirection;
    public Rigidbody rigidBody;
    private KeyCode[] inputKeys;

    void Start()
    {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    }

    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3 (xMovement, 0, zMovement);

        for (int i = 0; i < inputKeys.Length; i++){
            var key = inputKeys[i];
            movementAcceleration = 5000;
            if (Input.GetKey(key)) {
                if (key == KeyCode.W){
                    moveDirection = transform.TransformDirection(Vector3.forward);
                }
                else if (key == KeyCode.S){
                    moveDirection = transform.TransformDirection(Vector3.back);
                }
                else if (key == KeyCode.A){
                    moveDirection = transform.TransformDirection(Vector3.left);
                }
                else if (key == KeyCode.D){
                    moveDirection = transform.TransformDirection(Vector3.right);
                }
                Vector3 movement = moveDirection.normalized * movementAcceleration * Time.deltaTime;
                movement = new Vector3 (movement.x, 0, movement.z);
                moveThePlayer(movement);
            }
            else{
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
            }
        }
    }

    void moveThePlayer(Vector3 movement) {
        rigidBody.AddForce(movement);
        character.UpdateAnimator(movement);
    }
    
}
