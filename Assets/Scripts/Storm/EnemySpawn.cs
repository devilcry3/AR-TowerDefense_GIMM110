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
    public GameObject[] enemyUndead = new GameObject[3];
    [SerializeField] GameObject enemySpawnPos;
    [SerializeField] float timeToSpawn = 4f; // Time in seconds to spawn an enemy
    [SerializeField] int maxEnemies = 10; // Maximum number of enemies that can be spawned
    public Transform[] waypoints;
    int unitCounter2 = 0;
    int maxEnemies2 = 10;
    public int berz = 0;
    float berzSpawn = 8f;
    private Coroutine currentCoroutine;

    // HideInInspector hides the variable from the inspector, but allows other scripts to access it if needed
    public int unitCounter = 0; // Counter for the number of enemies spawned

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
        StartCoroutine(SpawnTutorial());
        
        //Original spawn method for enemy units, was changed to account for different waves

        // Starts the coroutine to spawn enemies
        //A coroutine is a method that can pause execution and return control to
        //Unity but then continue where it left off on the following frame.
        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    timeToSpawn = 2f; // Time in seconds to spawn an enemy
        //    int maxEnemies = 25;
        //}
    }

    public void waveCheck(int wave)
    {

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            switch (wave)
            {
                case 1:
                    unitCounter = 0;
                    maxEnemies = 20;
                    timeToSpawn = 2.5f;
                    currentCoroutine = StartCoroutine(SpawnWave2());
                    break;
                case 2:
                    unitCounter = 0;
                    maxEnemies += 10;
                currentCoroutine = StartCoroutine(SpawnWave3());
                    StartCoroutine(Berzerk());
                break;
                default:
                    break;
            }
        }

    
    #endregion

    #region Coroutine Methods
    /// <summary>
    /// Spawns an enemy undead at regular intervals
    IEnumerator SpawnTutorial()
    {
        while (unitCounter < maxEnemies) // Infinite loop to keep spawning enemies
        {
            //if (unitCounter < maxEnemies)
           // {
                
                // Spawns an enemy undead at the enemy spawn position
                GameObject spawnedEnemy = Instantiate(enemyUndead[0], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy.transform.Rotate(0, 0, 180); // Rotates the enemy to face the user
                unitCounter++;
           // }

            yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
        }
    }

    IEnumerator SpawnWave2()
    {
        while (unitCounter < maxEnemies) // Infinite loop to keep spawning enemies
        {
            
                // Spawns an enemy undead at the enemy spawn position
                GameObject spawnedEnemy = Instantiate(enemyUndead[1], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy.transform.Rotate(0, 0, 180); // Rotates the enemy to face the user
                unitCounter++;
            

            yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
        }
    }

    IEnumerator SpawnWave3()
    {
        while (unitCounter < maxEnemies)
        {
            if (unitCounter < maxEnemies) // Infinite loop to keep spawning enemies
            {
                // Spawns an enemy undead at the enemy spawn position
                GameObject spawnedEnemy1 = Instantiate(enemyUndead[1], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);

                spawnedEnemy1.transform.Rotate(0, 0, 180); // Rotates the enemy to face the user

                unitCounter++;

                yield return new WaitForSeconds(timeToSpawn); // Waits for the specified time before spawning another enemy
            }
            
        }
    }
    IEnumerator Berzerk()
    {
        while (unitCounter2 < maxEnemies2)
        {
            if (unitCounter2 < maxEnemies2 && berz < 2) //Berserker spawn script
            {
                GameObject spawnedEnemy2 = Instantiate(enemyUndead[2], enemySpawnPos.transform.position, Quaternion.identity, enemySpawnPos.transform);
                spawnedEnemy2.transform.Rotate(0, 0, 180);
                unitCounter2++;
                berz++;
                yield return new WaitForSeconds(berzSpawn); // Waits for the specified time before spawning another enemy
            }
           yield return new WaitForSeconds(1f);
        }
    }
    #endregion
}


