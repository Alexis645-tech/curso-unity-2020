using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
   private Vector3 playerPrevius = Vector3.zero;
   private float distance = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = player.transform.position = playerPrevius;
        if (offset.magnitude < 1f)
        {
            return;
        }

        offset.Normalize();
        
        this.transform.position = player.transform.position - offset*distance;
        
        transform.LookAt(player.transform.position);
        playerPrevius = player.transform.position;
    }
}
