using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject quitMenuUI;
    public GameObject ResumeMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        quitMenuUI.SetActive(false);
       ResumeMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        quitMenuUI.SetActive(true);
        ResumeMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
}
