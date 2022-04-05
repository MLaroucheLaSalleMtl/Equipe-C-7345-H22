using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public GameObject deathScript;
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public int maxMana = 100;
    public int currentMana { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        } 
    }

    public void TakeDamage(int damage)
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

    public virtual void Die()
    {
        deathScript.GetComponent<DeathScreen>().DeathScreenScript();
    }
}
