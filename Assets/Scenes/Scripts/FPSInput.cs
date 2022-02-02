using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{

    [SerializeField] private float speed = 9f;
    [SerializeField] private CharacterController cc;

    private float gravity = -9.81f;
    private float yVelocity = 0f;
    private float yVelocityOnGround = -4f;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //global to local coordinated
        movement = transform.TransformDirection(movement);
        //fix diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1f);
        //Add speed before gravity
        movement *= speed;
        //add gravity
        yVelocity += gravity * Time.deltaTime;

        if (cc.isGrounded && yVelocity < 0.0)
        {
            yVelocity = yVelocityOnGround;
        }

        movement.y = yVelocity;
        cc.Move(movement * Time.deltaTime);
    }
}
