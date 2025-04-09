using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] Card firstCard;
    [HideInInspector] Card secondCard;

    float[] stage1Times = new float[3] { 25f, 20f, 15f };
    float[] stage2Times = new float[3] { 45f, 40f, 35f};

    public float time = 30.00f;
    public int cardCount = 0;
    public int difficulty = 1; // @김재영 수정
    public int curStage = 1;
    bool isFistClear = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // @김재영 (싱글톤 패턴 + 씬 넘어가도 유지)
        }
        else { Destroy(gameObject); }

#if UNITY_EDITOR
        // 테스트를 위해 매번 재실행 시 마다, PlayerPrefs 초기화 
        PlayerPrefs.DeleteAll();
#endif

    }

    #region 게임 세팅 및 시작
    public void SettingGame()
    {
        Time.timeScale = 1.0f;

        //프로젝트 수정 (PlayerPrefs에서 난이도 불러오기)
        if (PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            difficulty = PlayerPrefs.GetInt("SelectedDifficulty");

            // 난이도에 따라 시간 설정
            switch (this.curStage)
            {
                case 1:
                    this.time = this.stage1Times[difficulty - 1]; // @김재영 - 에러나서 -1 붙였습니다
                    break;
                case 2:
                    this.time = this.stage2Times[difficulty - 1];
                    break;
            }
        }
    }

    IEnumerator GameStart()
    {
        while (this.time >= 0)
        {
            this.time -= Time.deltaTime;
            UIManager.Instance.SetTimeText(this.time);
            yield return null; // 다음 프레임까지 대기
        }

        UIManager.Instance.SetTimeText(0);
        UIManager.Instance.SetGameOverUI(true);
        Time.timeScale = 0.0f;
    }

    // UI Manager가 활성화됐는지 체크 후, 게임 시작
    public void UIManagerOnEnable() => StartCoroutine(GameStart());

    #endregion

    #region 게임 중
    public void isMatched()
    {
        // 두 카드가 일치하면 제거
        if (this.firstCard.index == this.secondCard.index)
        {
            this.firstCard.DestroyCard();
            this.secondCard.DestroyCard();
            this.cardCount -= 2;

            // 모든 카드를 제거하면 클리어
            if (this.cardCount == 0)
            {
                UIManager.Instance.SetGameSuccessUI(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            // 일치하지 않으면, 다시 뒤집기
            this.firstCard.CloseCard();
            this.secondCard.CloseCard();
        }

        // 초기화
        this.firstCard = null;
        this.secondCard = null;
    }

    // private 변수에 대한 접근 함수
    // 매니저의 역할 분리를 위함
    public Card GetFirstCard() { return this.firstCard; }
    public Card GetSecondCard() { return this.secondCard; }
    public void SetFirstCard(Card card) => this.firstCard = card;
    public void SetScondCard(Card card) => this.secondCard = card;
    #endregion

    #region 스테이지 해금
    // Lv 3의 스테이지를 클리어했을 떄,
    // 다음 스테이지의 해금을 위해 클리어 정보 저장
    public void Clear3Lv()
    {
        PlayerPrefs.SetInt($"Stage{this.curStage}_Clear", 1);
        PlayerPrefs.Save();
        this.isFistClear = true;
    }

    public void OnEnableStageLock(StageLock stageLock)
    {
        // StageLock이 활성화 됐을 때,
        // 현재 스테이지의 Lv 3가 첫 클리어인 건지 체크 후,
        // 해금 애니메이션 재생
        if (this.isFistClear) 
        { 
            stageLock.UnLock(); 
            this.isFistClear = false; 
        }
    }
    #endregion
}