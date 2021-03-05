using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteController : MonoBehaviour
{

    private Animator _animator;
    private const string moveHands = "Move Hand";
    private bool isMOvingHand = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(moveHands, isMOvingHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMOvingHand = !isMOvingHand;
            _animator.SetBool(moveHands, isMOvingHand);
        }
    }
}
