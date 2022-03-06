using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{

    Resolution[] resolutions;
    public Dropdown resoDropdown;

    public AudioMixer audioMixer;


    public void Start()
    {
        resolutions = Screen.resolutions.Select(resulotion => new Resolution { width = resulotion.width, height = resulotion.height }).Distinct().ToArray();
        int currentReso = 0;

        resoDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentReso = i;
            }
        }

        resoDropdown.AddOptions(options);
        resoDropdown.value = currentReso;
        resoDropdown.RefreshShownValue();
    }

    public void DropReso(int resoInd)
    {
        Resolution resolution = resolutions[resoInd];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ToogleFS(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SliderSound(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

   
}
