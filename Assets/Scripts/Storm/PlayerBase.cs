using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Base Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over!");
            // Add Game Over logic here
        }
    }
}
