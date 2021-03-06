using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10f;
    public float xRange = 17f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        
        //Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right*Time.deltaTime*horizontalInput*speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(x: xRange, transform.position.y, transform.position.z);
        }
        
        //Acciones del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
 