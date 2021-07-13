using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{

    public GameObject[] locations;

    public Transform pathwayHolder;

    public NavMeshAgent monsterNav;

    public GameObject player;

    public static bool playerSeen = false;

    public bool changingWaypoint = false;

    public bool waypointReached = false;

    public static int currentWaypoint = 0;

    void OnDrawGizmos() {
        foreach (Transform waypoint in pathwayHolder) {
            Gizmos.DrawSphere(waypoint.position, 0.5f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //Create a way to randomize first waypoint

        //locations = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    // Update is called once per frame
    void Update()
    {

        if (!playerSeen && !changingWaypoint) {
            MoveToWaypoint();
        } else if(playerSeen) {
            monsterNav.SetDestination(player.transform.position);
            //ChasePlayer();
        }
        
    }

    void ChangeWaypoint() {

        Debug.Log("Changing waypoint!");

        Vector3[] waypoints = new Vector3[pathwayHolder.childCount];
        int randomWaypoint;

        if (changingWaypoint) {

            randomWaypoint = Random.Range(0, waypoints.Length);

            Debug.Log("Random waypoint is " + randomWaypoint);

            currentWaypoint = randomWaypoint;
            Debug.Log("Enemy Waypoint changed to " + currentWaypoint);
        }

        /**
        do {

            randomWaypoint = Random.Range(0, waypoints.Length);

            Debug.Log("Random waypoint is " + randomWaypoint);

            if (randomWaypoint != currentWaypoint) {
                currentWaypoint = randomWaypoint;
                Debug.Log("Enemy Waypoint changed to " + currentWaypoint);
            }

        } while (randomWaypoint == currentWaypoint);

        **/
        changingWaypoint = false;

    }

    void MoveToWaypoint() {
        monsterNav.SetDestination(pathwayHolder.GetChild(currentWaypoint).transform.position); 
    }

    void ChasePlayer() {
        monsterNav.SetDestination(player.transform.position);     
    }

    void OnTriggerEnter(Collider other) {

        //int index = locations[i];

        if(other.CompareTag("Waypoint")) {
            Debug.Log("Reached current waypoint!");
            changingWaypoint = true;
            ChangeWaypoint();
        }

        if(other.CompareTag("Player")) {
            Debug.Log("Got you!");
            //Application.Quit();
        }
        
    }

}
