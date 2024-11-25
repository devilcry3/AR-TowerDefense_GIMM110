using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    [SerializeField] private float speed = 1f; // speed of rotation
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
            Health Health = other.GetComponent<Health>();
            if (Health != null)
            {
                // Apply damage and start periodic damage
                Health.TakeDamage(damage);
                StartCoroutine(ApplyPeriodicDamage(Health));
            }
        }
    }

    private IEnumerator ApplyPeriodicDamage(Health Health)
    {
<<<<<<< Updated upstream
        while (Health != null && Health.currentHealth > 0)
=======
        while (Health != null && Health.IsAlive)
>>>>>>> Stashed changes
        {
            yield return new WaitForSeconds(damageInterval);
            Health.TakeDamage(damage);
        }
    }
}