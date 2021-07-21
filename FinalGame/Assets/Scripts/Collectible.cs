using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerStay(Collider other) {

        Debug.Log("Collision!");

        if(other.CompareTag("Player") && PlayerMovement.interact) {

            if(this.gameObject.CompareTag("LoungeKey")) {
                Debug.Log("Picked up Lounge Key!");
                PlayerMovement.keyCollected = true;
            }

            if(this.gameObject.CompareTag("GeneratorPart")) {
                Debug.Log("Picked up Generator Part!");
                PlayerMovement.partCollected = true;
            }

            this.gameObject.SetActive(false);
        }
    }
}
