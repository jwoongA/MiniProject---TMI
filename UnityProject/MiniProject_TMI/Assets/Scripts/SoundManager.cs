using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject OptionBtn;
    
    public void ToggleSlider()
    {
        if (OptionBtn != null)
        {
            OptionBtn.SetActive(!OptionBtn.activeSelf);
            
        }
    }
   
    AudioSource audioSource;
    public AudioClip clip;
    
  

   
    public void popSound()
    {
        audioSource.PlayOneShot(clip);
    }
}
