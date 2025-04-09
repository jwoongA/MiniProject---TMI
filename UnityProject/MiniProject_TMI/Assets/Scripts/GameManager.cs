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
    public int difficulty = 1; // @���翵 ����
    public int curStage = 1;
    bool isFistClear = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // @���翵 (�̱��� ���� + �� �Ѿ�� ����)
        }
        else { Destroy(gameObject); }

#if UNITY_EDITOR
        // �׽�Ʈ�� ���� �Ź� ����� �� ����, PlayerPrefs �ʱ�ȭ 
        PlayerPrefs.DeleteAll();
#endif

    }

    #region ���� ���� �� ����
    public void SettingGame()
    {
        Time.timeScale = 1.0f;

        //������Ʈ ���� (PlayerPrefs���� ���̵� �ҷ�����)
        if (PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            difficulty = PlayerPrefs.GetInt("SelectedDifficulty");

            // ���̵��� ���� �ð� ����
            switch (this.curStage)
            {
                case 1:
                    this.time = this.stage1Times[difficulty - 1]; // @���翵 - �������� -1 �ٿ����ϴ�
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
            yield return null; // ���� �����ӱ��� ���
        }

        UIManager.Instance.SetTimeText(0);
        UIManager.Instance.SetGameOverUI(true);
        Time.timeScale = 0.0f;
    }

    // UI Manager�� Ȱ��ȭ�ƴ��� üũ ��, ���� ����
    public void UIManagerOnEnable() => StartCoroutine(GameStart());

    #endregion

    #region ���� ��
    public void isMatched()
    {
        // �� ī�尡 ��ġ�ϸ� ����
        if (this.firstCard.index == this.secondCard.index)
        {
            this.firstCard.DestroyCard();
            this.secondCard.DestroyCard();
            this.cardCount -= 2;

            // ��� ī�带 �����ϸ� Ŭ����
            if (this.cardCount == 0)
            {
                UIManager.Instance.SetGameSuccessUI(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            // ��ġ���� ������, �ٽ� ������
            this.firstCard.CloseCard();
            this.secondCard.CloseCard();
        }

        // �ʱ�ȭ
        this.firstCard = null;
        this.secondCard = null;
    }

    // private ������ ���� ���� �Լ�
    // �Ŵ����� ���� �и��� ����
    public Card GetFirstCard() { return this.firstCard; }
    public Card GetSecondCard() { return this.secondCard; }
    public void SetFirstCard(Card card) => this.firstCard = card;
    public void SetScondCard(Card card) => this.secondCard = card;
    #endregion

    #region �������� �ر�
    // Lv 3�� ���������� Ŭ�������� ��,
    // ���� ���������� �ر��� ���� Ŭ���� ���� ����
    public void Clear3Lv()
    {
        PlayerPrefs.SetInt($"Stage{this.curStage}_Clear", 1);
        PlayerPrefs.Save();
        this.isFistClear = true;
    }

    public void OnEnableStageLock(StageLock stageLock)
    {
        // StageLock�� Ȱ��ȭ ���� ��,
        // ���� ���������� Lv 3�� ù Ŭ������ ���� üũ ��,
        // �ر� �ִϸ��̼� ���
        if (this.isFistClear) 
        { 
            stageLock.UnLock(); 
            this.isFistClear = false; 
        }
    }
    #endregion
}