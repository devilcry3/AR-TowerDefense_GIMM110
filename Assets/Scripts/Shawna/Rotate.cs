using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    [SerializeField] private float speed = 1f; 
    [SerializeField] private int damage = 3; // Damage dealt to enemies
    [SerializeField] private float damageInterval = 0.5f; // Time between consecutive damage to the same enemy

    private void Update ()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is an enemy
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Apply damage and start periodic damage
                enemyHealth.TakeDamage(damage);
                StartCoroutine(ApplyPeriodicDamage(enemyHealth));
            }
        }
    }

    private IEnumerator ApplyPeriodicDamage(EnemyHealth enemyHealth)
    {
        while (enemyHealth != null && enemyHealth.IsAlive)
        {
            yield return new WaitForSeconds(damageInterval);
            enemyHealth.TakeDamage(damage);
        }
    }
}