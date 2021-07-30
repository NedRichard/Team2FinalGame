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
    public static bool playerCrouch = false;
    Vector3 playerRot;

    //Player Animations
    public Animator animator;

    //Obsolete
    public bool isMoving;

    //Player FOV
    public float viewRadius;
    public float fovAngle;
    RaycastHit hit;

    //Enemy distance 
    public GameObject Enemy;

    //Player interactions

    public static bool interact = false;

    /**
    public static bool keyCollected = false;
    public static bool loungeDoorOpened = false;
    public static bool partCollected = false;
    public static bool generatorFixed = false;

    **/

    //public static bool noteRead = false;


    void OnDrawGizmos() {

        //Draw view radius sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        //Draw enemy direction
        Gizmos.DrawRay(transform.position, (Enemy.transform.position - transform.position).normalized * viewRadius);

    }

    void Start() {
        playerBody = this.GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {

        if (Input.GetButtonDown("Jump")) {
            interact = true;
        } else {
            interact = false;
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            //Debug.Log("Player is crouching!");
            playerCrouch = !playerCrouch;
            animator.SetBool("isCrouching", true);
        }
        else{
            animator.SetBool("isCrouching", false);
        }
    }

    void FixedUpdate() {

        //Vector3 forwardInput = new Vector3(0, 0, verticalMov);

        
        if(!playerCrouch) {

            //Take Player inputs
            horizontalMov = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * playerRotationSpeed;
            verticalMov = Input.GetAxis("Vertical") * Time.fixedDeltaTime * playerSpeed;

            //Move Player
            MovePlayer();

            //CODE FOR LIISA
            if(horizontalMov > 0 || verticalMov > 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
            //CODE FOR LIISA

        }
        
        //Check Enemy within range
        EnemyInRange(transform, Enemy, viewRadius);

        //Quaternion deltaRot = Quaternion.Euler(playerRot * Time.fixedDeltaTime);

        
        //playerBody.MoveRotation(playerBody.rotation * deltaRot);

    }

    void EnemyInRange(Transform player, GameObject Enemy, float targetRad) {

        float distToEnemy = Vector3.Distance(player.position, Enemy.transform.position);

            if(distToEnemy <= targetRad) {
                GameManager.enemyClose = true;
                //Debug.Log("Enemy is close!");
            } else {
                GameManager.enemyClose = false;
            }

        /**

        Vector3 dirToEnemy = (Enemy.transform.position - player.position).normalized;
        dirToEnemy.y = 0;

        if(Physics.Raycast(player.position + Vector3.zero, dirToEnemy, out hit, viewRadius)) {

            if(LayerMask.LayerToName(hit.transform.gameObject.layer) == "Enemy") {
                GameManager.enemyClose = true;
                Debug.Log("Enemy is close!");
            }
        } else {
            GameManager.enemyClose = false;
        }

        **/

    }

    void MovePlayer() {

        //Forward movement
        Vector3 targetPos = transform.position + (transform.forward * verticalMov);
        playerBody.MovePosition(targetPos);
        //Debug.Log(transform.eulerAngles);

        //Player rotation
        Quaternion targetRot = transform.rotation * Quaternion.Euler(Vector3.up * horizontalMov);
        playerBody.MoveRotation(targetRot);
        //Debug.Log(transform.eulerAngles);

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
