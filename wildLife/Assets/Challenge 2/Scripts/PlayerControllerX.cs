using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float counter = 0f;
    private float nextWaitTime = 1f;
    // Update is called once per frame
    void Update()
    {
        counter = counter + Time.deltaTime;
        if (counter >= nextWaitTime && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, 
                    transform.position, dogPrefab.transform.rotation);
            counter = 0;
        }
    }
}
