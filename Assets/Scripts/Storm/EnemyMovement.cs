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

    //BarbedWire Requisition variables
    private bool isInWire = false;

    // Freezing variables
    private bool isFrozen = false;
    private Vector2 savedPosition;

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
        // If frozen, do not process movement
        if (isFrozen)
        {
            return;
        }

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



