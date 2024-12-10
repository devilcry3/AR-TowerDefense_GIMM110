using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damagePerSecond = 1; // Damage per undead per second
    private int undeadInDangerZone = 0; // Tracks number of enemies in Danger Zone
    private Health playerHealth; // Cached reference to Player Base's Health

    private void Start()
    {
        // Cache the Player Base Health component
        playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy enters the attack zone
        if (other.gameObject.layer == 8)
        {
            undeadInDangerZone++;

            if (undeadInDangerZone == 1)
            {
                StartCoroutine(ApplyDamage());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Stop applying damage when enemy leaves the attack zone
        if (other.gameObject.layer == 8)
        {
            undeadInDangerZone--;
            if (undeadInDangerZone <= 0)
            {
                undeadInDangerZone = 0;
            }
        }
    }

    private IEnumerator ApplyDamage()
    {
        while (undeadInDangerZone > 0)
        {
            // Apply damage to Player Base while inside the attack zone
            if (playerHealth != null)
            {
                int totalDamage = damagePerSecond * undeadInDangerZone;
                //Debug.Log($"Applying damage. Undead count: {undeadInDangerZone}, Total Damage: {totalDamage}");
                playerHealth.TakeDamage(totalDamage); // Apply damage based on number of undead
            }

            yield return new WaitForSeconds(1f); // Wait for 1s to apply damage again
        }
        //Debug.Log("No undead in Danger Zone. Stopping damage application.");
    }
}
