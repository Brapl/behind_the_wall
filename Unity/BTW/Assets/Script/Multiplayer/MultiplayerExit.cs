using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerExit : MonoBehaviour
{
    public bool isInRange;
    public Text interactUI;
    public bool finished=false;
    public static MultiplayerExit instance;
    public MultiplayerGameOverManager MGOM;
    
    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Exit dans la scène");
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
            finished = true;
            if (Gemme.instance.c)
            {
                MGOM.ExitBD();
            }
            else
            {
                MGOM.ExitHD();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
}
