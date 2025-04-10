using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        // 저장된 볼륨 값 불러오기 (기본값 1f)
        float savedBGM = PlayerPrefs.GetFloat("bgmSource", 1f);
        float savedSFX = PlayerPrefs.GetFloat("sfxSource", 1f);

        // AudioSource에 볼륨 적용
        bgmSource.volume = savedBGM;
        sfxSource.volume = savedSFX;

        // 슬라이더 UI에도 적용
        if (bgmSlider != null) bgmSlider.value = savedBGM;
        if (sfxSlider != null) sfxSlider.value = savedSFX;
    }

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

   

    public float GetBGMVolume()
    {
        return bgmSource.volume;
    }
    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }

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

        if (PlayerPrefs.HasKey("bgmSource"))
        {
            float savedbgmvolume = PlayerPrefs.GetFloat("bgmSource");
            bgmSource.volume = savedbgmvolume;
        }
        if (PlayerPrefs.HasKey("sfxSource"))
        {
            float savedsfxvolume = PlayerPrefs.GetFloat("sfxSource");
            sfxSource.volume = savedsfxvolume;
        }
    }

    public void SetBGMVolume(float value)
    {
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("bgmSource", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("sfxSource", value);
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
}
