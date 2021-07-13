using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFOV : MonoBehaviour
{
    public float radius;

    public float angle;

    public GameObject player;

    void OnDrawGizmos() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
