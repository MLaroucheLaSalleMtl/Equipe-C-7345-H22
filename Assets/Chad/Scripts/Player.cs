using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    Transform target;
    public Interactible focus;

    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    Camera cam;

    

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
                RemoveFocus();
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100))
            {
                Interactible interactible = hitInfo.collider.GetComponent<Interactible>();
                if (interactible != null)
                {
                    SetFocus(interactible);
                }
            }
        }

        if (target != null)
        {
            myAgent.SetDestination(target.position);
            FaceTarget();
        }

    }

    public void FollowTarget (Interactible newFocus)
    {
        myAgent.stoppingDistance = newFocus.radius * .8f;
        myAgent.updateRotation = false;

        target = newFocus.interationTransform;
        
    }

    public void StopFollowingTarget()
    {
        myAgent.stoppingDistance = 0f;
        myAgent.updateRotation = true;
        target = null;
        
    }

    void SetFocus (Interactible newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDeFocused();

            focus = newFocus;
            FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
 
    }

    void RemoveFocus ()
    {
        if (focus != null)
            focus.OnDeFocused();
        
        focus = null;
        StopFollowingTarget();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
