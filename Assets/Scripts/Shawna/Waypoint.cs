using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private Vector2 savedPosition;
    [SerializeField] private float speed = 5f;
    bool isFrozen;


   private void Update()
    {

        if (!isFrozen)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        }
        if (isFrozen)
        {
            return;
        }

    }

    public void Freeze()
    {
        if (!isFrozen)
        {
            isFrozen = true;
            savedPosition = transform.position; // Save current position
            //moveSpeed = 0;
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
