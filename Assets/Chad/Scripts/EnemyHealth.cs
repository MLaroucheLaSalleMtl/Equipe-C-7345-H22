using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (health > 0)
            {
                health -= 25f;
            }
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void SetMaxHealth()
    {
        health = maxHealth;
    }
}