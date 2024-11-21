using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10; // Damage per attack
    public float attackCooldown = 1f; // Time (in seconds) between attacks
    private bool canAttack = true; // Flag to track if attack is allowed

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the enemy is colliding with the Player Base
        if (collision.gameObject.CompareTag("Player Base") && canAttack)
        {
            Debug.Log("Enemy Touching player base");
            DealDamage(collision.gameObject); // Apply damage to the Player Base
            StartCoroutine(AttackCooldown()); // Start the cooldown coroutine
            Debug.Log("Damage Applied");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player Base"))
        {
            Debug.Log("Enemy not touching");
        }
    }

    private void DealDamage(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage); // Apply damage to the player base
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false; // Prevent further attacks during the cooldown
        Debug.Log("Cooldown Started");

        // Wait for the duration of the cooldown
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true; // Allow the enemy to attack again
        Debug.Log("Cooldown Finished");
    }
}
