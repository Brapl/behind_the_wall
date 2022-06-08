using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject dialogUI;
    public GameObject interactUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        gameIsPaused = true;
        Cursor.visible = true;
        pauseMenu.gameObject.SetActive(true);
        dialogUI.gameObject.SetActive(false);
        interactUI.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        gameIsPaused = false;
        dialogUI.gameObject.SetActive(true);
        interactUI.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
