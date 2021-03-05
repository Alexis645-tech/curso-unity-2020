using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [Range(5,40),SerializeField]
    private float speed = 10;
    [Range(5,90), SerializeField]
    private float rotationSpeed = 20;
    private float verticalInput;
    private float horizontalInput;
    private float upInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Jump")*10;
        horizontalInput = Input.GetAxis("Horizontal");
        upInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(speed*Time.deltaTime*Vector3.forward);
        transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput);
        transform.Rotate(rotationSpeed*Time.deltaTime*Vector3.up*horizontalInput);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(rotationSpeed*Time.deltaTime*Vector3.left*upInput);
         }
}
