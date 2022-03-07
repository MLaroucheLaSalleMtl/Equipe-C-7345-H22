using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public new ParticleSystem particleSystem;

    public GameObject spark;

    public float damage = 50f;

    //public float attackSpeed = 1f;
    //private float attackCooldown = 0f;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent> { };

    private void Update()
    {
        if (Input.GetButtonDown("Button2"))
        {
            particleSystem.Play();
        }
        //attackCooldown -= Time.deltaTime;
         
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = particleSystem.GetCollisionEvents(other, colEvents);

        //if (other.gameObject.tag == "Player")
        //{
        //    Physics.IgnoreCollision(other.collider);
        //}

        for (int i = 0; i < events; i++)
        {
            Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }

        if (other.TryGetComponent(out EnemyHealth en))
        {
            en.TakeDamage(damage);
        }

        //if (attackCooldown <= 0f)
        //{
        //    en.TakeDamage(damage);
        //    attackCooldown = 1f / attackSpeed;
        //}

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Physics.IgnoreCollision(collision.collider1, collider);
    //    }
    //}
}
