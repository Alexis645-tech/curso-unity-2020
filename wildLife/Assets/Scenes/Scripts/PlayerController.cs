using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField,Range(1, 50)]
    private float speed = 20;

    private Rigidbody _rigidbody;

    private float vertticalInput, horizontalInput;

    private float range = 24;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vertticalInput = Input.GetAxis("Vertical");
        
        MovePlayer();
        
        LimiteDelPLayer();
        
        //TODO: Sirve para anotar las tareas por hacer
    }

    void MovePlayer()
    {
        // Si se utiliza la física
        // AddForce sobre el rigidbody
        // AddTorque sobre el rigidbody
        _rigidbody.AddForce(Vector3.forward*Time.deltaTime*speed*vertticalInput, ForceMode.Force);
        _rigidbody.AddTorque(Vector3.up*Time.deltaTime*speed*horizontalInput, ForceMode.Force);
        
        // Si no se utiliza la física
        // Translate sobre el transform -> para mover
        // Rotate sobre el transform -> para rotar
        transform.Translate(Vector3.forward*Time.deltaTime*speed*vertticalInput);
        transform.Rotate(Vector3.up*Time.deltaTime*speed*horizontalInput);
    }

    void LimiteDelPLayer()
    {
        if (Mathf.Abs(transform.position.x)>=range || Mathf.Abs(transform.position.z)>=range)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > range)
            {
                transform.position = new Vector3(range, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -range)
            {
                transform.position = new Vector3(-range, transform.position.y, transform.position.z);
            }
            if (transform.position.z > range)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, range);
            }
            if (transform.position.z < -range)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -range);
            }
        } 
    }
}
