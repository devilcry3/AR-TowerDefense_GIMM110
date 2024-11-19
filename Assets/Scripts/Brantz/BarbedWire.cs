using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbedWire : MonoBehaviour
{
    //To be placed in Enemy movement script...DO NOT ATTACH TO ANYTHING!!

    private bool isInWire = false;
    [SerializeField] private float wireSlowFactor = 0.5f; // How much slower the movement is while in wire
    private float moveSpeed = 3f;



    private void ApplyMovement()
    {
        float currentMoveSpeed = isInWire ? moveSpeed * wireSlowFactor : moveSpeed; //if isInWire is true, apply the wireSlowactor, else return moveSpeed
    }


    // Handle collisions with Wire box collider
    private void OnTriggerEneter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wire"))
        {
            isInWire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wire"))
        {
            isInWire = false;
        }
    }


}
