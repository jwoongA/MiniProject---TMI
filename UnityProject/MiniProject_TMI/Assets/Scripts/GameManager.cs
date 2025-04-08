using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public Card firstCard;
    [HideInInspector] public Card secondCard;

    float[] stage1Times = new float[3] { 25f, 20f, 15f };
    float[] stage2Times = new float[3] { 45f, 40f, 35f};

    public float time = 30.00f;
    public int cardCount = 0;
    public int difficulty = 1; // @���翵 ����
    int curStage = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // @���翵 (�̱��� ���� + �� �Ѿ�� ����)
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        //������Ʈ ���� (PlayerPrefs���� ���̵� �ҷ�����)
        if (PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            difficulty = PlayerPrefs.GetInt("SelectedDifficulty");

            // ���̵��� ���� �ð� ����
            //switch (difficulty)
            //{
            //    case 1:
            //       time = 25f;
            //        break;
            //    case 2:
            //       time = 20f;
            //        break;
            //    case 3:
            //       time = 15f;
            //        break;
            //    case 4:
            //       time = 45f;
            //        break;
            //    case 5:
            //       time = 40f;
            //        break;
            //    case 6:
            //       time = 35f;
            //        break;
            //}

            switch (this.curStage)
            {
                case 1:
                    this.time = this.stage1Times[difficulty];
                    break;
                case 2:
                    this.time = this.stage2Times[difficulty];
                    break;
            }
            StartCoroutine(GameStart());
        }

    }
    public IEnumerator GameStart()
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


    public void isMatched()
    {
        if (this.firstCard.index == this.secondCard.index)
        {
            this.firstCard.DestroyCard();
            this.secondCard.DestroyCard();
            this.cardCount -= 2;

            if (this.cardCount == 0)
            {
                UIManager.Instance.SetGameSuccessUI(true);
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            this.firstCard.CloseCard();
            this.secondCard.CloseCard();
        }

        this.firstCard = null;
        this.secondCard = null;
    }

    public Card GetFirstCard() { return this.firstCard; }
    public Card GetSecondCard() { return this.secondCard; }
    public void SetFirstCard(Card card) => this.firstCard = card;
    public void SetScondCard(Card card) => this.secondCard = card;

}