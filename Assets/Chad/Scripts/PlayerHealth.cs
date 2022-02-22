using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damage = 10f;
    }

    //Taking Damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (health > 0)
            {
                health -= 15f;
            }
            else
                // Restart to the current level
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
