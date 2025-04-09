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
        // null일 때 instance하는 것을 방지하기 위함
        GameManager.Instance.UIManagerOnEnable();
    }

    private void Start()
    {
        this.stageInfoTxt.text = GameManager.Instance.GetCurStageInfo();
    }

    // 게임 중 시간 Text 변경
    public void SetTimeText(float time) 
    {
        if (this.timeTxt != null) // 혹시 모를 null 체크
        {
            this.timeTxt.text = time.ToString("N2");
        }
    }

    // 게임 오버 UI의 활성화/비활성화 관리
    public void SetGameOverUI(bool active)
    {
        AudioManager.instance.Playover();
        this.gameOverUI.SetActive(active);
        if (this.remainingCardCount != null) // 혹시 모를 null 체크
        {
            // 실패 시, 남은 카드 개수 Text 표시
            this.remainingCardCount.text = $"{GameManager.Instance.cardCount.ToString()}장";
        }
    }

    // 게임 성공 UI의 활성화/비활성화 관리
    public void SetGameSuccessUI(bool active)
    {
        this.gameSuccessUI.SetActive(active);

        // Lv 3를 처음 클리어한 것인지 체크
        bool firstClear = GameManager.Instance.GetCurStageClearInfo() == 0;
        if (GameManager.Instance.difficulty == 3 && firstClear) 
        { 
            // 첫 클리어라면 해금을 위해 다시하기 버튼을 없앰
            // 그리고 Clear 정보 저장
            this.btnRetrySuccess.SetActive(false);
            GameManager.Instance.Clear3Lv();
        }
    }

}
