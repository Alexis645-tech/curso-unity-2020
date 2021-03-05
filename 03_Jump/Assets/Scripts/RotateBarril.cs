using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBarril : MonoBehaviour
{

    public float rotate = 50;
    private float speed = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
        transform.Rotate(Vector3.up*rotate*Time.deltaTime);
    }
}
