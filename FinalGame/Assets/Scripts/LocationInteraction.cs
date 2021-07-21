using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInteraction : MonoBehaviour
{

    public GameObject loungeDoor;

    void Start() {
        loungeDoor = GameObject.FindWithTag("Lounge Door");
    }

    void OnTriggerStay(Collider other) {

        Debug.Log("On the interaction spot!");

        if(this.gameObject.CompareTag("LoungeDoorTrigger")) {

            if(other.CompareTag("Player") && PlayerMovement.keyCollected && PlayerMovement.interact) {
                loungeDoor.SetActive(false);
                this.gameObject.SetActive(false);
            }

        }

        if(this.gameObject.CompareTag("ClosetTrigger")) {

            if(other.CompareTag("Player") && PlayerMovement.partCollected && PlayerMovement.interact) {
                PlayerMovement.generatorFixed = true;
                this.gameObject.SetActive(false);
            }

        }

        if(this.gameObject.CompareTag("Lobby Exit")) {

            if(other.CompareTag("Player") && PlayerMovement.generatorFixed && PlayerMovement.interact) {
                
                Debug.Log("Got out!");
            }

        }

    }

}
