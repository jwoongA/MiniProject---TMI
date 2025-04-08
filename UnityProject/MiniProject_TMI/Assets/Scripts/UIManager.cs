using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Text")]
    [SerializeField] Text timeTxt;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetTimeText(float time)
    {
        this.timeTxt.text = time.ToString("N2");
    }

    public void OpenGameOverUI()
    {
        
    }
}
