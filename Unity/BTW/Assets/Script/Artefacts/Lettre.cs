using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lettre : MonoBehaviour
{
    public bool isInRange;
	public DialogueUI dialogue;
    public Text interactUI;
    public bool c;
    public static Lettre instance;
    
    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Lettre dans la scène");
            return;	
        }
        instance = this;
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            c = true;
            interactUI.enabled = true;
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
        }
    }
	void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
