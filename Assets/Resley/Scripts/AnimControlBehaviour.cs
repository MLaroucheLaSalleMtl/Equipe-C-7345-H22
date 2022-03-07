using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimControlBehaviour : MonoBehaviour
{
    public GameObject thePlayer;

    NavMeshAgent agent;
    Animator animator;

    const float locomotionAnimationSmothTime = .1f;

   //public bool enabled;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        //player = GetComponent<Player>();
        //enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmothTime, Time.deltaTime);

        if (Input.GetButtonDown("Button1"))
        {
            thePlayer.GetComponent<Animator>().Play("Sword And Shield Slash");
           // if (moveDir != Vector3.zero && anim.GetBool("attack") != true) ;
        }

        if (Input.GetButtonDown("Button2"))
        {
            thePlayer.GetComponent<Animator>().Play("Standing 1H Magic Attack 01");
        }
    }
}
