using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTower : MonoBehaviour
{
    private Health playerHealth; // Cached reference to Player Base's Health

    private void Start()
    {
        // Cache the Player Base Health component
        playerHealth = GameObject.FindWithTag("PlayerBase").GetComponent<Health>();
    }
    private void Update()
    {
      
    }
    
    public void RepairTowers()
    {
        //We need to tag all towers with the "Tower" tag.
        //This code finds all objects with the Tower tag.
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
       
       // Debug.Log($"{towers.Length} towers are on the field.");

        //For loop to check each tower and restore health to max.
        foreach (GameObject tower in towers)
        {
            Health health = tower.GetComponent<Health>();
            if (health != null)
            {
               // Debug.Log($"Restoring health for: {tower.name}, Current Health: {health.currentHealth}");
                health.RestoreAllHealth();
               // Debug.Log($"New Health for {tower.name}: {health.currentHealth}");
            }
        }
        if (playerHealth != null)
        {
            Health health = playerHealth.GetComponent<Health>();
            if (health != null)
            {
                // Debug.Log($"Restoring health for: {tower.name}, Current Health: {health.currentHealth}");
                health.RestoreAllHealth();
                // Debug.Log($"New Health for {tower.name}: {health.currentHealth}");
            }
        }
    }
}
