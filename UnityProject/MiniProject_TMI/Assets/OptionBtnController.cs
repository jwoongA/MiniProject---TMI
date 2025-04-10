using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionBtnController : MonoBehaviour
{
    [SerializeField] private GameObject optionBtn;

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
        string currentScene = scene.name;

        if (currentScene == "StartScene" || currentScene == "StageScene")
        {
            if (optionBtn != null) optionBtn.SetActive(true);
        }
        else if (currentScene == "GameScene")
        {
            if (optionBtn != null) optionBtn.SetActive(false);
        }
    }
}
