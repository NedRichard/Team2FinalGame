using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterScript : MonoBehaviour
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
    public static bool playerInSight;

    //For FOV functions
    public float radius;
    public float angle;
    Vector3 viewDirection;
    RaycastHit hit;
    //public float fieldOfView = 90f;
    //public float viewDistance = 30f;

    //GameObject player for target

    void OnDrawGizmos() {

        foreach (Transform waypoint in pathwayHolder) {
            Gizmos.DrawSphere(waypoint.position, 0.5f);
        }

        //Draw the sphere around enemy
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        //Define the limits of FOV visuals
        Vector3 fovLimit1 = Quaternion.AngleAxis(angle, transform.up) * transform.forward * radius;
        Vector3 fovLimit2 = Quaternion.AngleAxis(-angle, transform.up) * transform.forward * radius;

        //Draw the limit visuals
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLimit1);
        Gizmos.DrawRay(transform.position, fovLimit2);

        //Change ray color based on player visibility status
        if (playerInSight) {
            Gizmos.color = Color.green;
        } else if (!playerInSight) {
            Gizmos.color = Color.red;
        }

        //Draws the line between the enemy and player
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * radius);

        //Draw the forward position (Face towards)
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * radius);

        //Old ray for player direction
        //Gizmos.DrawRay(new Vector3(this.transform.position.x, this.transform.position.y, 
        // this.transform.position.z), viewDirection.normalized * radius);

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //Create a way to randomize first waypoint?

    }

    void FixedUpdate() {

        playerInView(transform, player, angle, radius);

    }

    public void playerInView(Transform observer, GameObject player, float angle, float radius) {
        Vector3 direction = (player.transform.position - observer.position).normalized;
        direction.y *= 0;

        if(Physics.Raycast(observer.position + Vector3.zero, 
        (player.transform.position - observer.position).normalized, out hit, radius)) {

            if(LayerMask.LayerToName(hit.transform.gameObject.layer) == "Player") {

                float viewAngle = Vector3.Angle(observer.forward + Vector3.zero, direction);

                if(viewAngle <= angle) {
                    playerInSight = true;
                } else {
                    playerInSight = false;
                }

            } else {
                playerInSight = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        if(monsterNav.gameObject.transform.position != locations[currentWaypoint].transform.position && !playerInSight) 
        {
            monsterNav.SetDestination(locations[currentWaypoint].transform.position);
        }

        if ((monsterNav.gameObject.transform.position.x == locations[currentWaypoint].transform.position.x) 
        && (monsterNav.gameObject.transform.position.z == locations[currentWaypoint].transform.position.z) && !playerInSight) {
            //Debug.Log("Reached current waypoint!");
            changingWaypoint = true;
            ChangeWaypoint();
        }

        if(playerInSight) {
            ChasePlayer();
        }

        //FOV search

        /**
        viewDirection = player.transform.position - this.transform.position;

        angle = Vector3.Angle(viewDirection, this.transform.position);

        if (angle < fieldOfView * 0.5f) {

            if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y, 
            this.transform.position.z), viewDirection.normalized, out hit, viewDistance)) 
            {

                if (hit.collider.tag == "Player") {
                    Debug.Log("Player in sight!");
                }

            }


        }

        **/

        /**

        if (!playerSeen && !changingWaypoint) {
            //MoveToWaypoint();

            if(monsterNav.gameObject.transform.position != locations[currentWaypoint].transform.position) {
                monsterNav.SetDestination(locations[currentWaypoint].transform.position);
            }

        } else if(playerSeen) {
            monsterNav.SetDestination(player.transform.position);
            //ChasePlayer();
        }

        if (monsterNav.gameObject.transform.position == locations[currentWaypoint].transform.position) {
            Debug.Log("Reached current waypoint!");
            changingWaypoint = true;
            ChangeWaypoint();
        }

        **/
        
    }

    void ChangeWaypoint() {

        Debug.Log("Changing waypoint!");

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

        if ((monsterNav.gameObject.transform.position.x == locations[currentWaypoint].transform.position.x) 
        && (monsterNav.gameObject.transform.position.z == locations[currentWaypoint].transform.position.z)) 
        {
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
            //Debug.Log("Got you!");
            Application.Quit();
        }
        
    }

}
