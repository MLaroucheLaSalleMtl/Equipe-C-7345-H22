using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIStatsManager : MonoBehaviour
{
    public GameObject StatsPanel;

    private bool StatsPanelActive = false;

    public PlayerStatuts playerStatuts;

    public TMP_Text playerName;
    public TMP_Text playerLevel;
    public TMP_Text playerHP;
    public TMP_Text playerMP;
    public TMP_Text playerEXP;
    public TMP_Text playerAttack;
    public TMP_Text playerDefense;
    public TMP_Text playerNextLevel;

    private void Start()
    {
        UpdatePlayerStatuts();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpdatePlayerStatuts();
            StatsPanelActive = !StatsPanelActive;

            if (StatsPanelActive == true)
            {
                StatsPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            if (StatsPanelActive == false)
            {
                StatsPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    public void UpdatePlayerStatuts()
    {
        playerName.text = playerStatuts.playerName;
        playerLevel.text = playerStatuts.playerLevel.ToString();
        playerHP.text = "" + playerStatuts.currentHp + "/" + playerStatuts.maxHp;
        playerMP.text = "" + playerStatuts.currentMp + "/" + playerStatuts.maxMp;
        playerEXP.text = "" + playerStatuts.currentExp;
        playerAttack.text = "" + playerStatuts.attack;
        playerDefense.text = "" + playerStatuts.defense;
        playerNextLevel.text = "" + playerStatuts.nextLevelExp[playerStatuts.playerLevel];
    }
}
