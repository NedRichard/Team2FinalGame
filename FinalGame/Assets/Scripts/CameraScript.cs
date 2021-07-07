using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public GameObject cameraOn;

    public GameObject cameraOff;

    //public Camera startCamera;

    //public Camera cameraOne;

    //public Camera cameraTwo;

    public bool camOn = false;

    public int cameraNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {
            cameraOn.SetActive(true);
            cameraOff.SetActive(false);

            //cameraOne.enabled = true;

            //cameraTwo.enabled = false;

        }

    }

}
