using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{

    public NavMeshAgent monsterNav;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer() {
        monsterNav.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other) {

        if(other.CompareTag("Player")) {
            Debug.Log("Got you!");
            //Application.Quit();
        }
        
    }

}
