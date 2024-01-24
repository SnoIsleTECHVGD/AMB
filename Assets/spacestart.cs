using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacestart : MonoBehaviour
{
    public static bool isGameStarted = false;
    public GameObject PlayerObj;
    [SerializeField] GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGameStarted)
            {
               
                PauseGame();
            }
            else
            {
                PlayerObj.gameObject.GetComponent<PlayerMovement>().enabled = true;
                ResumeGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGameStarted = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGameStarted = true;
    }
}