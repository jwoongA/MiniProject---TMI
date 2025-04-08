using System.Threading;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public Card firstCard;
    [HideInInspector] public Card secondCard;

    public float time = 30.00f;
    public int cardCount = 0;
    public int difficulty = 1; // @김재영 수정

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // @김재영 (싱글톤 패턴 + 씬 넘어가도 유지)
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;

        //프로젝트 수정 (PlayerPrefs에서 난이도 불러오기)
        if (PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            difficulty = PlayerPrefs.GetInt("SelectedDifficulty");

            // 난이도에 따라 시간 설정
            switch (difficulty)
            {
                case 1:
                   time = 25f;
                    break;
                case 2:
                   time = 20f;
                    break;
                case 3:
                   time = 15f;
                    break;
                case 4:
                   time = 45f;
                    break;
                case 5:
                   time = 40f;
                    break;
                case 6:
                   time = 35f;
                    break;
            }
        }

    }

    void Update()
    {
        if (this.time >= 0)
        {
            this.time -= Time.deltaTime;
            UIManager.Instance.SetTimeText(this.time);
        }
        else
        {
            UIManager.Instance.SetTimeText(0);
            UIManager.Instance.SetGameOverUI(true);
            Time.timeScale = 0.0f;
        }
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