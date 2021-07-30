using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    //public GameObject LoungeKeyText;
    //public GameObject GeneratorPartText;
    //public GameObject InteractText;

    //public GameObject gameManager;

    public AudioSource pickKey;
    public AudioSource pickFuse;

    void Start() {
        //LoungeKeyText.SetActive(false);
        //GeneratorPartText.SetActive(false);
        //InteractText.SetActive(false);
    }

    void OnTriggerStay(Collider other) {

        //Debug.Log("Collision!");

        if(other.CompareTag("Player") && PlayerMovement.interact) {

            if(this.gameObject.CompareTag("LoungeKey")) {
                //Debug.Log("Picked up Lounge Key!");
                GameManager.keyCollected = true;

                pickKey.Play();
                //LoungeKeyText.SetActive(true);
                //InteractText.SetActive(false);

                GameManager.ShowLoungeKeyText();
                GameManager.HideInteractiveText();
            }

            if(this.gameObject.CompareTag("GeneratorPart")) {
                //Debug.Log("Picked up Generator Part!");
                GameManager.partCollected = true;
                pickFuse.Play();
                //GeneratorPartText.SetActive(true);
                //InteractText.SetActive(false);

                GameManager.ShowGeneratorPartText();
                GameManager.HideInteractiveText();
            }

            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter() {
        //InteractText.SetActive(true);
        GameManager.ShowInteractiveText();
    }

    void OnTriggerExit() {
        //InteractText.SetActive(false);
        GameManager.HideInteractiveText();
    }
}
