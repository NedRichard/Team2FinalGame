using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{

    //For waypoint navigation
    public GameObject[] locations;
    public NavMeshAgent monsterNav;
    public Transform pathwayHolder;
    public bool changingWaypoint = false;
    public bool waypointReached = false;
    public static int currentWaypoint = 0;


    //For targeting player
    public GameObject player;
    public static bool playerSeen = false;


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

        //Debug.Log("Changing waypoint!");

        //Vector3[] waypoints = new Vector3[pathwayHolder.childCount];
        Vector3[] waypoints = new Vector3[locations.Length];

        int lastWaypoint = currentWaypoint;

        Debug.Log("Last waypoint is " + lastWaypoint);

        int randomWaypoint = Random.Range(0, waypoints.Length);

        Debug.Log("Next waypoint is " + randomWaypoint);

        currentWaypoint = randomWaypoint;

        while(lastWaypoint == randomWaypoint) {
            randomWaypoint = Random.Range(0, waypoints.Length);
            currentWaypoint = randomWaypoint;
        }

        

        /**

        if (changingWaypoint) {

            randomWaypoint = Random.Range(0, waypoints.Length);

            Debug.Log("Random waypoint is " + randomWaypoint);

            currentWaypoint = randomWaypoint;
            Debug.Log("Enemy Waypoint changed to " + currentWaypoint);
        }

        **/

        /**
        do {

            randomWaypoint = Random.Range(0, waypoints.Length);

            Debug.Log("Random waypoint is " + randomWaypoint);

            if (randomWaypoint != currentWaypoint) {
                currentWaypoint = randomWaypoint;
                Debug.Log("Enemy Waypoint changed to " + currentWaypoint);
            }

            currentWaypoint = randomWaypoint;

        } while (randomWaypoint == currentWaypoint);
        **/

        
        changingWaypoint = false;

    }

    void MoveToWaypoint() {
        //monsterNav.SetDestination(pathwayHolder.GetChild(currentWaypoint).transform.position); 

        if(monsterNav.gameObject.transform.position != locations[currentWaypoint].transform.position) {
            monsterNav.SetDestination(locations[currentWaypoint].transform.position);
        }

        if (monsterNav.gameObject.transform.position == locations[currentWaypoint].transform.position) {
            changingWaypoint = true;
            ChangeWaypoint();
        }

        
    }

    void ChasePlayer() {
        monsterNav.SetDestination(player.transform.position);     
    }

    void OnTriggerEnter(Collider other) {

        
        //Currently not used
        if(other.CompareTag("Waypoint")) {
            //Debug.Log("Reached current waypoint!");
            changingWaypoint = true;
            ChangeWaypoint();
        }

        if(other.CompareTag("Player")) {
            Debug.Log("Got you!");
            //Application.Quit();
        }
        
    }

}
