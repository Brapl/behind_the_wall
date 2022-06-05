using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public DialogueUI dialogue1;
    public DialogueUI dialogue2;
    public DialogueUI dialogue3;
    public static GameOverManager instance;

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
        gameOverUI.SetActive(true);
        DialogueManager.instance.StartDialogue(dialogue1);
    }

    public void MainMenuButton()
    {
        Debug.Log("MainMenu");
    }

    public void ExitBD()
    {
        gameOverUI.SetActive(true);
        DialogueManager.instance.StartDialogue(dialogue2);
    }
    public void ExitHD()
    {
        gameOverUI.SetActive(true);
        DialogueManager.instance.StartDialogue(dialogue3);
    }
}
