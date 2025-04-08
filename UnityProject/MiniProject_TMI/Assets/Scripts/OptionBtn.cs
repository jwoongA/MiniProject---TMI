using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionBtn : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void popSound()
    {
        audioSource.PlayOneShot(clip);
    }


}

