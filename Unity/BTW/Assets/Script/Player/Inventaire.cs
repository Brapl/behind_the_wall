using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    public static GameObject[] inv = new GameObject[5];
    public GameObject[] inventaire = inv;
    public int or;

    
    public static void AddItem(GameObject item)
    {
        bool itemAdded = false;
        //Recherche le premier emplacement libre
        for (int i = 0; i < inv.Length; i++)
        {
            if (inv[i] == null)
            {
                inv[i] = item;
                Debug.Log(item.name + " ajouté a l'inventaire");
                itemAdded = true;
                //Interaction
                item.SendMessage("DoInteraction");
                break;
            }
        }
        
        //Inventaire plein
        if (!itemAdded)
        {
            Debug.Log("Inventaire plein");
        }
    }

    private void Update()
    {
        
    }
}

