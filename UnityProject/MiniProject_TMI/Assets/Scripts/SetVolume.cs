using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetBGM (float sliderValue)
    {
        audioMixer.SetFloat("BGMVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFX (float sliderValue)
    {
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetMaster (float sliderValue)
    {
        audioMixer.SetFloat("MasterVol", Mathf.Log(sliderValue) * 20);
    }
}
