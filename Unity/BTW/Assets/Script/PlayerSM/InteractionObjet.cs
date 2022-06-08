using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class InteractionObjet : MonoBehaviour
{
    public bool inventaire; // true => peut être mis dans l'inventaire
    public void DoInteraction()
    {
        //Ramasser 
        gameObject.SetActive(false);
    }

    

    
}

