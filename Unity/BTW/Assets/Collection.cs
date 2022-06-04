using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public GameObject squelet;

    // Update is called once per frame
    void Update()
    {
        squelet.SetActive(iscollected());
    }
    private bool iscollected()
    {
        if (Journal.c ==true && Article.c==true && Cercle.c==true && Lettre.c==true && Légende.c==true && Rose.c==true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
