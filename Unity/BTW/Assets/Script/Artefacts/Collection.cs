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
        if (Journal.instance.c ==true && Article.instance.c==true && Cercle.instance.c==true && Lettre.instance.c==true && Légende.instance.c==true && Rose.instance.c==true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
