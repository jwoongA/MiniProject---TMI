using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionBtn : MonoBehaviour
{

    private AudioManager audioManager;

    public GameObject optionMenu;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene scene, LoadSceneMode mode)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "StageScene")
        {
            gameObject.SetActive(true);
        }
        else if (currentScene == "StartScene" || currentScene == "GameScene")
        {
            gameObject.SetActive(false);
        }
    }

    public void ToggleOptionMenu()
    {
        if (optionMenu != null)
        {
            optionMenu.SetActive(!optionMenu.activeSelf);
            AudioManager.instance.Playclick();
        }
     
    }
}



