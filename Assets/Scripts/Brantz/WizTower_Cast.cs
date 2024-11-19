using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizTower_Cast : MonoBehaviour
{
    // Variables
    public GameObject fireballPrefab;   // Reference fireball prefab
    public Transform firePoint;         // Spawn point for projectile
    [SerializeField] float fireRate = 2.5f;  // Fire rate (in seconds)
    private float fireCooldown = 0f;


    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Transform target = FindClosestEnemy();
            if (target != null)
            {
                Shoot(target);
                fireCooldown = fireRate;
            }
        }

    }

    void Shoot(Transform target)
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Fireball_Projectile fireballScript = fireball.GetComponent<Fireball_Projectile>();

        if (fireballScript != null)
        {
            fireballScript.SetTarget(target);
        }
    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestEnemy = enemy.transform;
            }

        }

        return closestEnemy;

    }

}
