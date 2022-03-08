using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseMenuMultiplayer : MonoBehaviourPunCallbacks
{
    bool gameIsPaused = false;

    public GameObject pauseMenu;

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
        Cursor.visible = true;
        gameIsPaused = true;
        pauseMenu.gameObject.SetActive(true);
    }

    public void Resume()
    {
        Cursor.visible = false;
        gameIsPaused = false;
        pauseMenu.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }
}
