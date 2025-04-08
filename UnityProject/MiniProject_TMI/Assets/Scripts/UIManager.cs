using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Text")]
    [SerializeField] Text timeTxt;
    [SerializeField] Text remainingCardCount;

    [Header("Object")]
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameSuccessUI;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SetTimeText(float time) => this.timeTxt.text = time.ToString("N2");
    public void SetGameOverUI(bool active)
    {
        this.gameOverUI.SetActive(active);
        this.remainingCardCount.text = $"{GameManager.Instance.cardCount.ToString()}Àå";
    }
    public void SetGameSuccessUI(bool active) => this.gameSuccessUI.SetActive(active);
}
