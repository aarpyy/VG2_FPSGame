using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWayPoints : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float playerDetectRange = 1f; // range within which the player can trigger the helicopter movement
    public Transform player;

    private int currentWaypointIndex = 0;
    private bool playerClose = false; // flag indicating if the player is close to the helicopter

    void Update()
    {
        // check if the player is close to the helicopter
        if (!playerClose && Vector3.Distance(transform.position, player.position) < playerDetectRange)
        {
            playerClose = true;
        }

        // If the player is close, move the helicopter towards the first waypoint
        if (playerClose)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                // move to the next waypoint
                currentWaypointIndex++;
                // if the current waypoint index exceeds the number of waypoints, reset it to 0
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
        }
    }
}
