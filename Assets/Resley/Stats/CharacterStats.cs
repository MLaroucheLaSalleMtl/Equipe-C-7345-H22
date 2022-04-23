using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public GameObject deathScript;
    public float maxHealth = 100;

    private float minHealth = 0;
    public float currentHealth { get; private set; }

    public float maxMana = 100;

    private float minMana = 0;
    public float currentMana { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    private void Update()
    {

        //Test damage
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        //Test heal potion
        if (Input.GetKeyDown(KeyCode.Y))
        {
            HealBack(20);
        }
        //Test mana potion
        if (Input.GetKeyDown(KeyCode.N))
        {
            UseMana(20);
        }
        //Test mana potion
        if (Input.GetKeyDown(KeyCode.M))
        {
            ManaBack(20);
        }

    }

    //test damage
    public void TakeDamage(float damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes " + damage + " damages.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //Test healt refill
    public void HealBack(float heal)
    {

        currentHealth += heal;
        Debug.Log(transform.name + "Heal " + heal + " damages.");

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
        }

    }

    //Test mana usage
    public void UseMana (float manause)
    {
        currentMana -= manause;
        Debug.Log(transform.name + "Used " + manause + " mana.");
    }

    //Test mana refill
    public void ManaBack(float mana)
    {

        currentMana += mana;
        Debug.Log(transform.name + "Regenarated " + mana + " mana.");

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        if (currentMana < minMana)
        {
            currentMana = minMana;
        }

    }

    //Death
    public virtual void Die()
    {
        deathScript.GetComponent<DeathScreen>().DeathScreenScript();
    }


}
