using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatuts : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject deathScript;

    public string playerName, description;

    public int playerLevel;
    public int maxLevel;

    public int currentExp;
    public int[] nextLevelExp; // Enough XP = level up.

    public float currentHp, currentMp, maxHp, maxMp;
    public float attack, defense;

    private void Start()
    {
        nextLevelExp = new int[maxLevel + 1]; // Max level
        nextLevelExp[1] = 1000; // XP Required for first level

        for (int i = 2; i < maxLevel; i++)
        {
            nextLevelExp[i] = Mathf.RoundToInt(nextLevelExp[i - 1] * 1.1f);
        }
    }

    public void AddExp()
    {
        currentExp += 200;

        if (currentExp >= nextLevelExp[playerLevel] && playerLevel < maxLevel)
        {
            LevelUp();
        }

        if (playerLevel >= maxLevel)
        {
            currentExp = 0; // You have reached max level
        }
    }

    private void LevelUp()
    {
        currentExp -= nextLevelExp[playerLevel];
        playerLevel++; // Increase player level

        maxHp += 50f;
        currentHp = maxHp;
        maxMp += 10f;
        currentMp = maxMp;
        attack += 5f;
        defense += 1f;

        audioSource.Play();
    }

    // Damage on colision with enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (currentHp > 0f)
            {
                currentHp -= (10f - defense);
            }
            else if (currentHp <= 0f)
            {
                // Death function
                deathScript.GetComponent<DeathScreen>().DeathScreenScript();
            }
        }
    }
}