using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player positioning
    public GameObject Player;
    public Rigidbody playerBody;
    public float playerSpeed = 150f;
    public float playerRotationSpeed = 150f;
    
    //Player controls
    public float horizontalMov;
    public float verticalMov;
    Vector3 playerRot;

    //Obsolete
    public bool isMoving;

    //Player FOV
    public float viewRadius;
    public float fovAngle;
    RaycastHit hit;

    //Player interactions

    public static bool interact = false;
    public static bool keyCollected = false;

    public static bool loungeDoorOpened = false;
    public static bool partCollected = false;
    public static bool generatorFixed = false;
    public static bool noteRead = false;


    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }

    void Start() {
        playerBody = this.GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            interact = true;
        } else {
            interact = false;
        }
    }

    void FixedUpdate() {

        //Vector3 forwardInput = new Vector3(0, 0, verticalMov);

        

        horizontalMov = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * playerRotationSpeed;

        verticalMov = Input.GetAxis("Vertical") * Time.fixedDeltaTime * playerSpeed;

        MovePlayer();

        //Quaternion deltaRot = Quaternion.Euler(playerRot * Time.fixedDeltaTime);

        
        //playerBody.MoveRotation(playerBody.rotation * deltaRot);

    }

    void MovePlayer() {

        //Forward movement
        Vector3 targetPos = transform.position + (transform.forward * verticalMov);
        playerBody.MovePosition(targetPos);
        Debug.Log(transform.eulerAngles);

        //Player rotation
        Quaternion targetRot = transform.rotation * Quaternion.Euler(Vector3.up * horizontalMov);
        playerBody.MoveRotation(targetRot);
        Debug.Log(transform.eulerAngles);


    }

    void SimpleMove() {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {

            isMoving = true;

            horizontalMov = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;

            verticalMov = Input.GetAxis("Vertical") * Time.deltaTime * 4;

            Player.transform.Rotate(0, horizontalMov, 0);

            Player.transform.Translate(0, 0, verticalMov);


        } else {
            isMoving = false;
        }
    }
}
