using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float topBound = 30f;

    private float buttomBound = -10f;
    
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }

        if (this.transform.position.z < buttomBound)
        {
            Debug.Log("Game Over");
            Destroy((this.gameObject));

            Time.timeScale = 0;
        }
    }
}
