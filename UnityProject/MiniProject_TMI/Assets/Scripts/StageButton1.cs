using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public GameObject popupPanel;

    // Start is called before the first frame update
    public void ShowPopup(int stageNum)
    {
        popupPanel.SetActive(true);
        GameManager.Instance.curStage = stageNum;
        AudioManager.instance.Playclick();
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);
    }
}
