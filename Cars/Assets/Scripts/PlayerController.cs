using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 45), SerializeField, Tooltip("Velocidad máxima del carro")]
    private float speed = 20f;
    [Range(0,90), SerializeField, Tooltip("Velocidad máxmima de giro del carro")]
    private float turnSpeed = 45f;
    private float horizontalInput, verticalInput;   

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        this.transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput);
        this.transform.Rotate(turnSpeed*Time.deltaTime*Vector3.up*horizontalInput);
    }
}
