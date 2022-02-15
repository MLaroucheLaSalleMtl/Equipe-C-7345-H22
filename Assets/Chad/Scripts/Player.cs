using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    public Animator playerAnim;
    public bool isRunning;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
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
            }
        }

        if (myAgent.velocity != Vector3.zero)
        {
            playerAnim.SetBool("isRunning", true);
        }
        else if (myAgent.velocity == Vector3.zero)
        {
            playerAnim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnim.GetComponent<Animator>().Play("1HMagic");

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.GetComponent<Animator>().Play("SwordSlash");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerAnim.GetComponent<Animator>().Play("Roll");
        }

    }
}
