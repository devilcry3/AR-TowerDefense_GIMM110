using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Amount of damage the enemy deals per damage rate
    public int damageAmount = 10;
    //How often the damage is applied (in sceonds)
    public float damageRate = 1f;

    private float nextDamageTime = 0f;
    private bool isCollidingWithPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //makes sure enemy collides with player
        if (collision.CompareTag("PlayerBase"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBase"))
        {
            isCollidingWithPlayer = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // if enemy is colliding with the player, apply damage periodically
        if (isCollidingWithPlayer && Time.time >= nextDamageTime)
        {
            //sets the next time the enemy will deal damage
            nextDamageTime = Time.time + damageRate;
            ApplyDamageToPlayer();
        }
    }

    private void ApplyDamageToPlayer()
    {
        // finding health script to use as reference for damage
        Health health = FindObjectOfType<Health>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}
