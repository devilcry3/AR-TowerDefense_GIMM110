using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 targetPosition;
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;
    EnemySpawn spawn;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Use this for initialization
    private void Start()
    {
        spawn = GetComponent<EnemySpawn>();
        //waypoints = spawn.waypoints;
        // Initialize targetPosition to the position of the first waypoint
        if (EnemySpawn.Instance != null && EnemySpawn.Instance.waypoints.Length > 0)
        {
            waypoints = EnemySpawn.Instance.waypoints;
            targetPosition = waypoints[waypointIndex].position;
        }
        if (waypoints.Length > 0)
        {
            targetPosition = waypoints[waypointIndex].position;
        }
    }

    private void Update()
    {
       
        // Update the target position to match the current waypoint
        if (waypoints.Length > 0 && waypointIndex < waypoints.Length)
        {
            targetPosition = waypoints[waypointIndex].position;
            Move();
        }
    }

    private void Move()
    {
        // If Enemy didn't reach the last waypoint, it can move
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               targetPosition,
               moveSpeed * Time.deltaTime);

            // If the enemy is close to the target position, move to the next waypoint
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                waypointIndex += 1;

                // Check bounds before updating targetPosition
                if (waypointIndex < waypoints.Length)
                {
                    targetPosition = waypoints[waypointIndex].position;
                }
            }
        }
    }
}


