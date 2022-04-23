using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : Item
{
    [SerializeField] private int Health;

    [SerializeField] private int Mana;

    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
           // HealBack(20);
        }
    }
    //public void HealBack(float heal)
    //{

    //    currentHealth += heal;
    //    //Debug.Log(transform.name + "Heal " + heal + " damages.");

    //    if (currentHealth > maxHealth)
    //    {
    //        currentHealth = maxHealth;
    //    }
    //    if (currentHealth < minHealth)
    //    {
    //        currentHealth = minHealth;
    //    }

    //}
}
