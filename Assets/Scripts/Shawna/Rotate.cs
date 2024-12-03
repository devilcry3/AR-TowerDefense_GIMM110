using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    [SerializeField] private float speed = 1f; 
    [SerializeField] private int damage = 3; // Damage dealt to enemies
    [SerializeField] private float damageInterval = 0.5f; // Time between consecutive damage to the same enemy
    Health health;


    private void Start()
    {
         health = GetComponent<Health>();
    }

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is an enemy
        if (other.CompareTag("undead"))
        {
          
            if (health != null)
            {
                // Apply damage and start periodic damage
                health.TakeDamage(damage);
                StartCoroutine(ApplyPeriodicDamage(health));
            }
        }
    }

    private IEnumerator ApplyPeriodicDamage(Health health)
    {
        // Keep applying damage while health is above 0
        while (health != null && health.currentHealth > 0)
        {
            yield return new WaitForSeconds(damageInterval);
            health.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
