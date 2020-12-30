using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{


    public NavMeshAgent agent;
    public Camera mainCamera;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
     agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
                animator.SetBool("isWalking",true);
            RaycastHit hit;
            if(Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition),out hit)){
                agent.destination = hit.point;
                transform.LookAt(hit.point);
            }
        }
         if (!agent.pathPending)
 {
     if (CheckDestinationReached(agent.destination))
     {
        
                animator.SetBool("isWalking",false);
         
     }
 }
    }
    bool CheckDestinationReached(Vector3 target) {
  float distanceToTarget = Vector3.Distance(transform.position, target);
  return distanceToTarget < 1;
  
}
}
