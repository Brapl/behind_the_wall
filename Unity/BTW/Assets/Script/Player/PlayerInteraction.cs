using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class PlayerInteraction : MonoBehaviour
{
    public GameObject playerLight;
    public GameObject currentInterObj = null;
    public int vision;

    void Update()
    {
        if (vision != 0)
        {
            if (vision == 1)
            {
                playerLight.GetComponent<Light2D>().pointLightOuterRadius -= 3;
            }

            vision--;
        }
        if (Input.GetButtonDown("Interaction") && currentInterObj) 
        {
            if (currentInterObj.name.Split(' ')[0] == "Potion_soin")
            { 
                // Soigne le joueur 25% de sa vie
                currentInterObj.SetActive(false);
            }
            if (currentInterObj.name.Split(' ')[0] == "Potion_vie")
            { 
                // Soigne le joueur completement
                currentInterObj.SetActive(false);
            }
            if (currentInterObj.name.Split(' ')[0] == "Potion_vision")
            {
                playerLight.GetComponent<Light2D>().pointLightOuterRadius += 3;
                vision += 10000;
                currentInterObj.SetActive(false);
            }

        }
    }
    
    
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("InterObj"))
        {
            Debug.Log(col.name);
            currentInterObj = col.gameObject;
            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("InterObj"))
        { 
            if (col.CompareTag("InterObj")) 
                currentInterObj = null; 
        }
    }
}

