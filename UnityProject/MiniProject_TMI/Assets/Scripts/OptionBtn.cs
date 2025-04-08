using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionBtn : MonoBehaviour
{
   
    public GameObject optionMenu;

    public void ToggleOptionMenu()
    {
        if (optionMenu != null)
        {
            optionMenu.SetActive(!optionMenu.activeSelf);

            
            AudioManager.instance.Playclick();
        }
    }
}



