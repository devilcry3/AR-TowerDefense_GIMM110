using UnityEngine;

public class Spear : MonoBehaviour
{
    private int damage;

    // Method to set the damage value
    public void SetDamage(int damageValue)
    {
        damage = damageValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object hit has a Health component
        Health enemyHealth = collision.GetComponent<Health>();
        if (enemyHealth != null)
        {
            // Deal damage to the enemy
            enemyHealth.TakeDamage(damage);

            // Destroy the spear after hitting an enemy
            Destroy(gameObject);
        }
    }
}
