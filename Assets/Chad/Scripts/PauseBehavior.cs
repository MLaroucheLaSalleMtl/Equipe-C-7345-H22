using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehavior : MonoBehaviour
{
    public GameObject PauseUI;

    private void Start()
    {
        PauseUI = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
