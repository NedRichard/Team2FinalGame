using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;

    public Rigidbody playerBody;

    public float playerSpeed = 150f;

    public float playerRotationSpeed = 150f;

    public bool isMoving;

    public float horizontalMov;

    public float verticalMov;

    Vector3 playerRot;

    void Start() {
        playerBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //SimpleMove();

        //horizontalMov = Input.GetAxis("Horizontal") * Time.deltaTime * playerRotationSpeed;

        //verticalMov = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        //playerRot = new Vector3(0, horizontalMov, 0);

        


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

        //Player rotation
        Quaternion targetRot = transform.rotation * Quaternion.Euler(Vector3.up * horizontalMov);
        playerBody.MoveRotation(targetRot);


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
