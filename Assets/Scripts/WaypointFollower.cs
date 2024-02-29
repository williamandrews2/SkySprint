using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;
    void Update()
    {
        // Set to < .1 and not =0 due to small margins of error
        if(Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            // This refers to the transform component of the Floor4
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        

    }

    /* Explanation of the script:
     * We first create an array that will hold the waypoints of which a GameObject will travel
     * to. Next, we create an int that keeps track of what waypoint we are on. In the update
     * function, we check the distance between the object and the waypoints using 
     * "Vector3.Distance". We set the conditional to be < .1f instead of = 0 due to small 
     * amount of imprecision in Unity. Now that we are done at this waypoint, we increase the 
     * currentWaypointIndex to go the the next point. We check to ensure we are not at the last 
     * waypoint, and if we are we reset it back to 0 (the first waypoint).
     */
}
