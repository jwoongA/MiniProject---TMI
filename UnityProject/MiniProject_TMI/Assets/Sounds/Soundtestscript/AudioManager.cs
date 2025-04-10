using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject BGM;
    public GameObject SFX;

    private AudioSource bgmSource;
    private AudioSource sfxSource;

    public AudioClip clickClip;
    public AudioClip gameoverClip;
    public AudioClip gameclearClip;
    public AudioClip flipClip;
    public AudioClip correctClip;
    public AudioClip wrongClip;
    public AudioClip shareClip;
    public AudioClip warningClip;
    public AudioClip mainstgClip;
    public AudioClip stageClip;
    public AudioClip unlockClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           
            Destroy(gameObject);
        }

        bgmSource = BGM.GetComponent<AudioSource>();
        sfxSource = SFX.GetComponent<AudioSource>();
    }

    public void SetBGMVolume(float value)
    {
        bgmSource.volume = value;
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
    }

    public void Playclick() => sfxSource.PlayOneShot(clickClip);
    public void Playflip() => sfxSource.PlayOneShot(flipClip);
    public void Playshare() => sfxSource.PlayOneShot(shareClip);
    public void Playcorrect() => sfxSource.PlayOneShot(correctClip);
    public void Playwrong() => sfxSource.PlayOneShot(wrongClip);
    public void Playclear() => sfxSource.PlayOneShot(gameclearClip);
    public void Playover() => sfxSource.PlayOneShot(gameoverClip);
    public void Playwarning() => sfxSource.PlayOneShot(warningClip);
    public void Playunlock() => sfxSource.PlayOneShot(unlockClip);

    public void Stopbgm() => bgmSource.Stop();
    public void Playmain()

    {
        bgmSource.Stop();
        bgmSource.clip = mainstgClip;
        bgmSource.loop = true; // 반복 재생 원하면
        bgmSource.Play();
    }

    public void Playstage()
    {
        bgmSource.Stop();
        bgmSource.clip = stageClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    // 
    public bool playMainOnStart;
    public bool playStageOnStart;

    private void Start()
    {
        

        if (playMainOnStart)
        {
            
            Playmain();
        }

        if (playStageOnStart)
        {
           
            Playstage();
        }
    }

    

   
}
