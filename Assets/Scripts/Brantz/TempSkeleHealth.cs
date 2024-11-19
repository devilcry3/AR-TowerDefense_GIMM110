using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSkeleHealth : MonoBehaviour
{
    //Temporary script for testing wiz tower

    public int health = 30;


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}