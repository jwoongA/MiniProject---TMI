using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionBtn : MonoBehaviour
{
    public GameObject optionBtn;

    [SerializeField] private AudioMixerGroup sfxGroup;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = sfxGroup;
    }
    public void ToggleSlider()
    {
        if (optionBtn != null)
        {
            optionBtn.SetActive(!optionBtn.activeSelf);
            SoundManager.Playsound(SoundType.CLICK);
        }
    }

}

