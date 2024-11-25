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

<<<<<<< Updated upstream
    // BarbedWire Requisition variables
    private bool isInWire = false;

    // Freezing variables
    private bool isFrozen = false;
    private Vector2 savedPosition; // Save position during freeze

=======
    //BarbedWire Requisition variables
    private bool isInWire = false;

>>>>>>> Stashed changes
    // Use this for initialization
    private void Start()
    {
        spawn = GetComponent<EnemySpawn>();
<<<<<<< Updated upstream
        // Initialize waypoints from the EnemySpawn singleton instance
=======
        //waypoints = spawn.waypoints;
        // Initialize targetPosition to the position of the first waypoint
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        // If frozen, do not process movement
        if (isFrozen)
        {
            return;
        }

=======
       
>>>>>>> Stashed changes
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
            float currentMoveSpeed = isInWire ? moveSpeed * 0.25f : moveSpeed; // if isInWire is true, multiply moveSpeed by 0.25 (Slows it to 1/4 speed), otherwise return normal moveSpeed

            // Move Enemy from current waypoint to the next one
<<<<<<< Updated upstream
            transform.position = Vector2.MoveTowards(transform.position,
               targetPosition,
               currentMoveSpeed * Time.deltaTime);
=======
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               targetPosition,
               moveSpeed * Time.deltaTime);
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BarbedWire"))
        {
            isInWire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BarbedWire"))
        {
            isInWire = false;
        }
    }

<<<<<<< Updated upstream
    // Freeze the enemy
    public void Freeze()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            savedPosition = transform.position; // Save current position
        }
    }

    // Unfreeze the enemy
    public void Unfreeze()
    {
        if (isFrozen)
        {
            isFrozen = false;
        }
    }
}
=======

}


>>>>>>> Stashed changes
