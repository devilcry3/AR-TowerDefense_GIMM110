using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemies : MonoBehaviour
{
    [SerializeField] private float freezeDuration = 10f; // Duration of the freeze in seconds
    [SerializeField] private LayerMask enemyLayer; // Layer of enemies to be frozen
    


    private bool isFreezing = false;
    private void Start()
    {
       
    }
    void Update()
    {
        // Check if the player presses the freeze key and has enough coins
        if (Input.GetKeyDown(KeyCode.L) && !isFreezing)
        {
            Debug.Log("L pressed");
            StartCoroutine(FreezeAllEnemies());
        }
    }

    private IEnumerator FreezeAllEnemies()
    {
        Debug.Log("coroutine");
        isFreezing = true;

        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemies = new List<GameObject>();
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        // Filter GameObjects by their layer
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == 8)
            {

                enemies.Add(obj); // Add to the list
            }
        }
        Debug.Log(enemies.Count);

        List<EnemyMovement> frozenEnemies = new List<EnemyMovement>();  //Un comment to use with EnemyMovement script
        //List<Waypoint> frozenEnemies = new List<Waypoint>();    //Comment out if using the EnemyMovement script

        foreach (GameObject enemy in enemies)
        {
            Debug.Log("foreach");
            var enemyMovement = enemy.GetComponent<EnemyMovement>();  //Un comment to use with EnemyMovement script
            //var enemyMovement = enemy.GetComponent<Waypoint>();   //Comment out if using the EnemyMovement script

            if (enemyMovement != null)
            {
                enemyMovement.Freeze();
                frozenEnemies.Add(enemyMovement);
                Debug.Log("freeze");
            }
            if (enemyMovement == null)
            { Debug.Log("failed"); }
        }

        yield return new WaitForSeconds(freezeDuration);

        foreach (var frozenEnemy in frozenEnemies)
        {
            if (frozenEnemy != null) // Check to ensure it's valid
            {
                frozenEnemy.Unfreeze();
                Debug.Log("unfreeze");
            }
        }

        isFreezing = false;
    }
}