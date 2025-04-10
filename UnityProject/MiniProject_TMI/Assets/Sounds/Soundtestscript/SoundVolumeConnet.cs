using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundVolumeConnet : MonoBehaviour
{
   
    public enum VolumeType { BGM, SFX }
    public VolumeType volumeType;

    private void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        Slider slider = GetComponent<Slider>();

        if (audioManager == null || slider == null)
        {
            Debug.LogWarning("🔇 AudioManager 또는 Slider를 찾을 수 없습니다!");
            return;
        }

        // 초기 슬라이더 값 맞추기 (선택사항)
        if (volumeType == VolumeType.BGM)
        {
            slider.value = audioManager.GetBGMVolume(); // 만들면 좋음
            slider.onValueChanged.AddListener(audioManager.SetBGMVolume);
        }
        else if (volumeType == VolumeType.SFX)
        {
            slider.value = audioManager.GetSFXVolume(); // 만들면 좋음
            slider.onValueChanged.AddListener(audioManager.SetSFXVolume);
        }

        Debug.Log("🔊 슬라이더가 AudioManager에 자동 연결됨!");
    }
}

