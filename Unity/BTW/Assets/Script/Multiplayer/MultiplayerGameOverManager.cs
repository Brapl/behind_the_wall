using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiplayerGameOverManager : MonoBehaviour
{
    public Player _player;
    public GameObject interactUI;
    public GameObject healthbarUI;
    public GameObject gameOverUI;
    public DialogueUI dialogue1;
    public DialogueUI dialogue2;
    public DialogueUI dialogue3;
    public static MultiplayerGameOverManager instance;

    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;	
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        _player.onEnd = true;
        interactUI.SetActive(false);
        healthbarUI.SetActive(false);
        DialogueManager.instance.StartDialogue(dialogue1);
        Task.Delay(10000);
        gameOverUI.SetActive(true);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ExitBD()
    {
        _player.onEnd = true;
        interactUI.SetActive(false);
        healthbarUI.SetActive(false);
        DialogueManager.instance.StartDialogue(dialogue2);
        Task.Delay(10000);
        gameOverUI.SetActive(true);
    }
    public void ExitHD()
    {
        _player.onEnd = true;
        interactUI.SetActive(false);
        healthbarUI.SetActive(false);
        DialogueManager.instance.StartDialogue(dialogue3);
        Task.Delay(10000);
        gameOverUI.SetActive(true);
    }
}
