using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveScript : MonoBehaviour
{
    public Animator playerAnim;
    public bool isRunning;
    private NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (myAgent.velocity != Vector3.zero)
        //{
        //    playerAnim.SetBool("isRunning", true);
        //}
        //else if (myAgent.velocity == Vector3.zero)
        //{
        //    playerAnim.SetBool("isRunning", false);
        //}
    }
}
