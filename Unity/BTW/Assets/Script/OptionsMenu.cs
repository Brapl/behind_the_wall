using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void DropReso()
    {

    }

    public void ToogleFS()
    {

    }

    public void SliderSound(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
