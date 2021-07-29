using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    void OnTriggerStay(Collider other) {

        if(other.CompareTag("Player") && GameManager.keyCollected && PlayerMovement.interact) {
            this.gameObject.SetActive(false);
        }

    }
}
