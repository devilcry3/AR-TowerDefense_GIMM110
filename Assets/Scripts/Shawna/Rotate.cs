using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
    [SerializeField] private float speed = 1f; 
    [SerializeField] private int damage = 1; // Damage dealt to enemies
    [SerializeField] private float damageInterval = 0.5f; // Time between consecutive damage to the same enemy
    Health health;
    bool upgrade;


    private void Start()
    {
         health = GetComponent<Health>();
    }

    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if the object is an enemy
        if (other.CompareTag("Undead"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
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

    public void Boost()
    {

        if (!upgrade)
        {
            upgrade = true;
            Debug.Log("boost engaged");
            StartCoroutine(SharpEdge());
        }
    }
    IEnumerator SharpEdge()
    {

        damage = 2;
        yield return new WaitForSeconds(6);  // Ensure this is properly awaited
        upgrade = false;
        damage = 1;
        Debug.Log("Shing");
        yield break;
    }
}
