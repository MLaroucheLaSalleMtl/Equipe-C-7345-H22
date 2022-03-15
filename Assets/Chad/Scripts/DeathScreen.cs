using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathPanel;
    public void DeathScreenScript()
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        DeathPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
