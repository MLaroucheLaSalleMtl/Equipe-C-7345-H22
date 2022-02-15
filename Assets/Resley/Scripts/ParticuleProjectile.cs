using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleProjectile : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public GameObject spark;

    public float damage = 50f;

    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent> { };

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            particleSystem.Play();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
       int envents = particleSystem.GetCollisionEvents(other, colEvents);

        for (int i = 0; i < envents; i++)
        {
            Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }

        if (other.TryGetComponent(out EnemyHealth en))
        {
            en.TakeDamage(damage);
            //Destroy(gameObject, .2f);
        }
    }
}
