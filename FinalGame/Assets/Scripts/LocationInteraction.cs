using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInteraction : MonoBehaviour
{

    public GameObject loungeDoor;
    public GameObject generator;
    public GameObject InteractionText;
    public GameObject LobbyText;

    void Start() {
        loungeDoor = GameObject.FindWithTag("Lounge Door");
        InteractionText.SetActive(false);
    }

    void OnTriggerStay(Collider other) {

        //Debug.Log("On the interaction spot!");

        if(this.gameObject.CompareTag("LoungeDoorTrigger")) {

            if(other.CompareTag("Player") && PlayerMovement.keyCollected && PlayerMovement.interact) {
                loungeDoor.SetActive(false);
                PlayerMovement.loungeDoorOpened = true;
                InteractionText.SetActive(false);
                this.gameObject.SetActive(false);
            }

        }

        if(this.gameObject.CompareTag("ClosetTrigger")) {

            if(other.CompareTag("Player") && PlayerMovement.partCollected && PlayerMovement.interact) {
                PlayerMovement.generatorFixed = true;
                InteractionText.SetActive(false);
                LobbyText.SetActive(true);
                this.gameObject.SetActive(false);
            }

        }

        if(this.gameObject.CompareTag("Lobby Exit")) {

            if(other.CompareTag("Player") && PlayerMovement.generatorFixed && PlayerMovement.interact) {
                //SceneController.GoToVictoryScene();
                InteractionText.SetActive(false);
                //Debug.Log("Got out!");
            }

        }

    }

    void OnTriggerEnter() {
        InteractionText.SetActive(true);
    }

    void OnTriggerExit() {
        InteractionText.SetActive(false);
    }

}
