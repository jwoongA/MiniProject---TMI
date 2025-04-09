using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Text")]
    [SerializeField] Text timeTxt;
    [SerializeField] Text stageInfoTxt;
    [SerializeField] Text remainingCardCount;

    [Header("Object")]
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameSuccessUI;
    [SerializeField] GameObject btnRetrySuccess;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(this.gameObject); }
    }

    void OnEnable()
    {
        // null�� �� instance�ϴ� ���� �����ϱ� ����
        GameManager.Instance.UIManagerOnEnable();
    }

    private void Start()
    {
        this.stageInfoTxt.text = GameManager.Instance.GetCurStageInfo();
    }

    // ���� �� �ð� Text ����
    public void SetTimeText(float time) 
    {
        if (this.timeTxt != null) // Ȥ�� �� null üũ
        {
            this.timeTxt.text = time.ToString("N2");
        }
    }

    // ���� ���� UI�� Ȱ��ȭ/��Ȱ��ȭ ����
    public void SetGameOverUI(bool active)
    {
        AudioManager.instance.Playover();
        this.gameOverUI.SetActive(active);
        if (this.remainingCardCount != null) // Ȥ�� �� null üũ
        {
            // ���� ��, ���� ī�� ���� Text ǥ��
            this.remainingCardCount.text = $"{GameManager.Instance.cardCount.ToString()}��";
        }
    }

    // ���� ���� UI�� Ȱ��ȭ/��Ȱ��ȭ ����
    public void SetGameSuccessUI(bool active)
    {
        this.gameSuccessUI.SetActive(active);

        // Lv 3�� ó�� Ŭ������ ������ üũ
        bool firstClear = GameManager.Instance.GetCurStageClearInfo() == 0;
        if (GameManager.Instance.difficulty == 3 && firstClear) 
        { 
            // ù Ŭ������ �ر��� ���� �ٽ��ϱ� ��ư�� ����
            // �׸��� Clear ���� ����
            this.btnRetrySuccess.SetActive(false);
            GameManager.Instance.Clear3Lv();
        }
    }

}
