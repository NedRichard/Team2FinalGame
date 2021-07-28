using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LiisaTest : MonoBehaviour
{
    public NavMeshAgent navMesh;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponentInParent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(navMesh.speed <= 8)
        {
            anim.SetFloat("Speed", 7.5f);
        } 
        else if(navMesh.speed >= 8)
        {
            anim.SetFloat("Speed", 8.5f);
        }
    }
}
