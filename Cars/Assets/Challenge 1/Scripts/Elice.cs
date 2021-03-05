using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elice : MonoBehaviour
{
    
    private float movimiento = 1000000;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(movimiento*Time.deltaTime*Vector3.forward);
    }
}
