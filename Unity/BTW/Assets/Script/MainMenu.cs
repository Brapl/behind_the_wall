using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsWindow;
    public GameObject launcherWindow;

    public void SoloButton()
    {

    }

    public void MultiButton()
    {
        launcherWindow.gameObject.SetActive(true);
    }

    public void MultiButtonReturn()
    {
        launcherWindow.gameObject.SetActive(false);
    }

    public void SiteButton()
    {
        string url = "y'a pas encore de site";
        Application.OpenURL(url);
    }

    public void DidaButton()
    {
        SceneManager.LoadScene("Didactitiel");
    }

    public void OptionsButton() 
    {
        optionsWindow.gameObject.SetActive(true);
    }

    public void OptionsButtonReturn()
    {
        optionsWindow.gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
