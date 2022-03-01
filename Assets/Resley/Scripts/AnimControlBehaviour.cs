using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControlBehaviour : MonoBehaviour
{
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Button1"))
        {
            thePlayer.GetComponent<Animator>().Play("Sword And Shield Slash");
        }

        if (Input.GetButtonDown("Button2"))
        {
            thePlayer.GetComponent<Animator>().Play("1H Magic Attack 01");
        }
    }
}
