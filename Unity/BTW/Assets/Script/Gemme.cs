using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gemme : MonoBehaviour
{
    public bool isInRange;
    public Text interactUI;
    public bool c = false;
    public static Gemme instance;
    
    void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Gemme dans la scène");
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
            c=true;
            Destroy(gameObject);
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
