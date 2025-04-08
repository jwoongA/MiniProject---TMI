using System.Threading;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public Card firstCard;
    [HideInInspector] public Card secondCard;

    float time = 30.00f;
    public int cardCount = 0;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1.0f;
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