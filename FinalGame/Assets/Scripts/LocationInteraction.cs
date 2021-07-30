using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInteraction : MonoBehaviour
{

    public GameObject loungeDoor;
    public GameObject generator;
    //public GameObject InteractionText;
    //public GameObject LobbyText;

    public GameObject LoungeLockedText;
    public GameObject FuseMissingText;
    public GameObject LobbyLockedText;

    void Start() {
        loungeDoor = GameObject.FindWithTag("Lounge Door");
        //InteractionText.SetActive(false);
    }

    void OnTriggerStay(Collider other) {

        //Debug.Log("On the interaction spot!");

        if(this.gameObject.CompareTag("LoungeDoorTrigger")) {

            if(other.CompareTag("Player") && PlayerMovement.interact) {

                if(GameManager.keyCollected) {

                    GameManager.PlayDoorOpenSound();

                    loungeDoor.SetActive(false);
                    GameManager.loungeDoorOpened = true;
                    
                    //InteractionText.SetActive(false);
                    GameManager.HideInteractiveText();

                    this.gameObject.SetActive(false);
                } else {
                    GameManager.ShowLoungeLockedText();

                    //LoungeLockedText.SetActive(true);
                } 
                
            }

        }

        if(this.gameObject.CompareTag("ClosetTrigger")) {

            if(other.CompareTag("Player") && PlayerMovement.interact) {

                //Debug.Log("Stayed here");

                if(GameManager.partCollected) {

                    GameManager.PlayFixGeneratorSound();
                    GameManager.generatorFixed = true;
                    
                    //InteractionText.SetActive(false);
                    GameManager.HideInteractiveText();

                    //LobbyText.SetActive(true);
                    GameManager.ShowLobbyText();

                    this.gameObject.SetActive(false);

                } else {
                    GameManager.ShowFuseMissingText();
                    //GameManager.areaUIText = true;
                    //FuseMissingText.SetActive(true);
                }                     
                
            }

        }

        if(this.gameObject.CompareTag("Lobby Exit")) {

            if(other.CompareTag("Player") && PlayerMovement.interact) {

                if(GameManager.generatorFixed) {
                    SceneController.GoToVictoryScene();
                    //InteractionText.SetActive(false);
                    //Debug.Log("Got out!");
                } else {
                    GameManager.ShowLobbyLockedText();
                    //LobbyLockedText.SetActive(true);
                }            
                
            }

        }

    }

    void OnTriggerEnter() {
        //InteractionText.SetActive(true);
        GameManager.ShowInteractiveText();
    }

    void OnTriggerExit() {
        //InteractionText.SetActive(false);
        GameManager.HideInteractiveText();

        
            GameManager.HideFuseMissingText();
            GameManager.HideLobbyLockedText();
            GameManager.HideLoungeLockedText();

        //LoungeLockedText.SetActive(false);
        //FuseMissingText.SetActive(false);
        //LobbyLockedText.SetActive(false);

    }

}
