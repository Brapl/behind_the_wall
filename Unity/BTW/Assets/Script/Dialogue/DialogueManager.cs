using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public bool isend = false;
    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Dialogue Manager dans la scène");
            return;
        }

        instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialogueUI dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
        
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        isend = true;
    }
}
