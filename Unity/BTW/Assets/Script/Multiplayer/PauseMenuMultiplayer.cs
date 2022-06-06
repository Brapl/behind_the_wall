using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseMenuMultiplayer : MonoBehaviourPunCallbacks
{
    bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject chatSub;
    private bool isTyping;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)  )
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
        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (!isTyping)
            {
                isTyping = true;
                chatSub.SetActive(true);
            }
            else
            {
                ChatManager.SubmitChat();
                isTyping = false;
                chatSub.SetActive(false);
            }
        }
    }

    public void Pause()
    {
        Cursor.visible = true;
        gameIsPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Cursor.visible = false;
        gameIsPaused = false;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
       
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("MainMenu");
    }
}
