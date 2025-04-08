using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SoundType
{
    CLICK,
    CARDSHARE,
    GAMEOVER,
    GAMECLEAR,
    CORRECT,
    WRONG,
    CARDFLIP,
    WARNING,
    MAINBGM,
    STAGEBGM
}

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundlist;
    [SerializeField] private AudioMixer audioMixer;

    public static SoundManager Instance;
    private AudioSource audioSource;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }

    }



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void Playsound(SoundType sound, float volume = 1)
    {
        Instance.audioSource.PlayOneShot(Instance.soundlist[(int)sound], volume);
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1)) * 20);
    }

    public void SetBGMVolume(float value)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1)) * 20);
    }

    public void SetSFXVolume(float value)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1)) * 20);
    }

}
