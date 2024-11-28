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
    List<GameObject> enemies = new List<GameObject>();


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
        ListClear();
    }

    void ListClear()
    {
        enemies.RemoveAll(item => item == null);
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
       
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        // Filter GameObjects by their layer
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == 8)
            {
              
                enemies.Add(obj); // Add to the list
            }
        }
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
