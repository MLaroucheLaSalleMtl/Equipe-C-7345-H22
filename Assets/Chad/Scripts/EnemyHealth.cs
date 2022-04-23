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
            QuestManager.questManager.AddQuestItem("Kill slimes", 1);
            FindObjectOfType<PlayerStatuts>().AddExp();

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
                health -= 15;
            }
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= 15;
    }

    public void SetMaxHealth()
    {
        health = maxHealth;
    }
}