using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void SoloButton()
    {

    }

    public void MultiButton()
    {

    }

    public void SiteButton()
    {

    }

    public void DidaButton()
    {
        SceneManager.LoadScene("Didactitiel");
    }

    public void OptionsButton() 
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
