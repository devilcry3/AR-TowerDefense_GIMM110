using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemies : MonoBehaviour
{
    [SerializeField] private float freezeDuration = 10f; // Duration of the freeze in seconds
    [SerializeField] private int cost = 5; // Cost in coins to activate the freeze
    [SerializeField] private LayerMask enemyLayer; // Layer of enemies to be frozen
    [SerializeField] private Player player; // Reference to the player script managing coins

    private bool isFreezing = false;

    void Update()
    {
        // Check if the player presses the freeze key and has enough coins
        if (Input.GetKeyDown(KeyCode.F) && player.Coins >= cost && !isFreezing)
        {
            StartCoroutine(FreezeAllEnemies());
        }
    }

    private IEnumerator FreezeAllEnemies()
    {
        // Deduct the cost
        player.SpendCoins(cost);

        isFreezing = true;

        // Find all enemies within the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Disable movement for all enemies
        List<EnemyMovement> frozenEnemies = new List<EnemyMovement>();
        foreach (GameObject enemy in enemies)
        {
            EnemyMovement movement = enemy.GetComponent<EnemyMovement>();
            if (movement != null)
            {
                movement.Freeze();
                frozenEnemies.Add(movement);
            }
        }

        // Wait for the freeze duration
        yield return new WaitForSeconds(freezeDuration);

        // Re-enable movement for all previously frozen enemies
        foreach (EnemyMovement movement in frozenEnemies)
        {
            movement.Unfreeze();
        }

        isFreezing = false;
    }
}