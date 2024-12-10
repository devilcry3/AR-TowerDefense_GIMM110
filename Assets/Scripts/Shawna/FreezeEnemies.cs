using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FreezeEnemies : MonoBehaviour
{
    [SerializeField] private float freezeDuration = 10f; // Duration of the freeze in seconds
    [SerializeField] private LayerMask enemyLayer; // Layer of enemies to be frozen



    private bool isFreezing = false;


    public IEnumerator FreezeAllEnemies()
    {
        //Debug.Log("coroutine");
        isFreezing = true;

        // Filter GameObjects by their layer and tag in a single LINQ query
        List<GameObject> enemies = GameObject.FindObjectsOfType<GameObject>()
                                            .Where(obj => obj.layer == 8)
                                            .ToList();

        //Debug.Log(enemies.Count);

        // Initialize the list of frozen enemies
        List<EnemyMovement> frozenEnemies = new List<EnemyMovement>();

        // Freeze enemies and populate the frozenEnemies list
        foreach (var enemy in enemies)
        {
            var enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.Freeze();
                frozenEnemies.Add(enemyMovement);
               // Debug.Log("freeze");
            }
            else
            {
               // Debug.Log("failed");
            }
        }

        yield return new WaitForSeconds(freezeDuration);

        // Unfreeze enemies
        frozenEnemies.ForEach(frozenEnemy =>
        {
            if (frozenEnemy != null)
            {
                frozenEnemy.Unfreeze();
               // Debug.Log("unfreeze");
            }
        });

        isFreezing = false;
    }

   
}