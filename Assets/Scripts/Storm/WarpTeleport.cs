using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpTeleport : MonoBehaviour
{
    // List of enemy tags
    private readonly string[] enemyTags = { "Berserker", "Glow Undead", "Undead" };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is an enemy
        foreach (string tag in enemyTags)
        {
            if (collision.CompareTag(tag))
            {
                // Find the spawn point tagged "SpawnPoint" nearest to this enemy
                GameObject spawnPoint = FindNearestSpawnPoint(collision.transform);
                if (spawnPoint != null)
                {
                    // Teleport the enemy to the spawn point
                    collision.transform.position = spawnPoint.transform.position;

                    // Reset the waypoint path
                    EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();
                    if (enemyMovement != null)
                    {
                        enemyMovement.ResetPath();
                    }
                }
                return;
            }
        }
    }

    private GameObject FindNearestSpawnPoint(Transform enemyTransform)
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject nearestSpawnPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject spawnPoint in spawnPoints)
        {
            float distance = Vector2.Distance(enemyTransform.position, spawnPoint.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestSpawnPoint = spawnPoint;
            }
        }

        return nearestSpawnPoint;
    }
}


