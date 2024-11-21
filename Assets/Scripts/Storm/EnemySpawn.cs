using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Regions help to visually organize your code into sections.
    #region Variables
    // Static variables are shared across all instances of a class
    public static EnemySpawn Instance { get; private set; } // Singleton pattern that allows you to access the EnemySpawn instance from other scripts

    // Headers are like titles for the Unity Inspector.
    [Header("Enemy Spawns")]
    [SerializeField] GameObject[] enemyUndead = new GameObject[3];
    [SerializeField] GameObject enemySpawnPos;
    [SerializeField] float timeToSpawn = 4f; // Time in seconds to spawn an enemy
    [SerializeField] int maxEnemies = 10; // Maximum number of enemies that can be spawned
    [SerializeField] int wave = 1; //Indicates wave
    public Transform[] waypoints;

    // HideInInspector hides the variable from the inspector, but allows other scripts to access it if needed
    [HideInInspector] public int unitCounter = 0; // Counter for the number of enemies spawned
    #endregion // Marks the end of the region

    #region Unity Methods
    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // If the instance is null, set it to this instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroys the duplicate instance if it exists
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        switch (wave)
        {
            case 1:
                StartCoroutine(SpawnTutorial());
                break;
            case 2:
                maxEnemies = 20;
                timeToSpawn = 2.5f;
                StartCoroutine(SpawnWave2());
                break;
            case 3:
                maxEnemies += 20;
                StartCoroutine(SpawnWave3());
                break;
            default:
                break;
        }
        // Starts the coroutine to spawn enemies
        //A coroutine is a method that can pause execution and return control to
        //Unity but then continue where it left off on the following frame.
        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    timeToSpawn = 2f; // Time in seconds to spawn an enemy
        //    int maxEnemies = 25;
        //}
    }
    #endregion

    #region Coroutine Methods
    /// <summary>
    /// Spawns an enemy undead at regular intervals
    IEnumerator SpawnTutorial()
    {
        while (true) // Infinite loop to keep spawning enemies
        {
            if (unitCounter < maxEnemies)
            {
                
                // Spawns an enemy undead at the enemy spawn position
                GameObject spawnedEnemy = Instantiate(enemyUndead[0], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy.transform.Rotate(0, 0, 180); // Rotates the enemy to face the user
                unitCounter++;
            }

            yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
        }
    }

    IEnumerator SpawnWave2()
    {
        while (true) // Infinite loop to keep spawning enemies
        {
            if (unitCounter < maxEnemies)
            {
                // Spawns an enemy undead at the enemy spawn position
                GameObject spawnedEnemy = Instantiate(enemyUndead[1], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy.transform.Rotate(0, 0, 180); // Rotates the enemy to face the user
                unitCounter++;
            }

            yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
        }
    }

    IEnumerator SpawnWave3()
    {
        while (true) // Infinite loop to keep spawning enemies
        {
            if (unitCounter < maxEnemies)
            {
                // Spawns an enemy undead at the enemy spawn position
                GameObject spawnedEnemy1 = Instantiate(enemyUndead[1], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                GameObject spawnedEnemy2 = Instantiate(enemyUndead[2], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy1.transform.Rotate(0, 0, 180); // Rotates the enemy to face the user
                spawnedEnemy1.transform.Rotate(0, 0, 180);
                unitCounter++;
                unitCounter++;
            }

            yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
        }
    }
    #endregion
}


