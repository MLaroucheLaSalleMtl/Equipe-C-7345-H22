using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem particleSystem;

    public GameObject spark;

    public float damage = 50f;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent> { };

    private void Update()
    {
        if (Input.GetButtonDown("Button2"))
        {
            particleSystem.Play();
        }
         
    }

    private void OnParticleCollision(GameObject other)
    {
        int envents = particleSystem.GetCollisionEvents(other, colEvents);

        //if (other.gameObject.tag == "Player")
        //{
        //    Physics.IgnoreCollision(other.collider);
        //}

        for (int i = 0; i < envents; i++)
        {
            Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }

        if (other.TryGetComponent(out EnemyHealth en))
        {
            en.TakeDamage(damage);
           
        }


    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Physics.IgnoreCollision(collision.collider1, collider);
    //    }
    //}
}
