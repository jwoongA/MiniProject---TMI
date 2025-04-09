using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainButton : MonoBehaviour
{
    public void GoMain()
    {
        AudioManager.instance.Playclick();
        AudioManager.instance.Playmain();
        SceneManager.LoadScene("StageScene");

        Time.timeScale = 1.0f;
    }
}
