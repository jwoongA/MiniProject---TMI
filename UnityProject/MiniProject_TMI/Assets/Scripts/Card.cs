using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;

    [Header("Genaral")]
    [SerializeField] GameObject front;
    [SerializeField] GameObject back;

    [SerializeField] SpriteRenderer frontImage;

    public void Setting(int number)
    {   
        this.index = number;
        this.frontImage.sprite = Resources.Load<Sprite>($"Member{index}_Zep");
    }

    public void OpenCard()
    {
        this.front.SetActive(true);
        this.back.SetActive(false);

        if (GameManager.Instance.GetFirstCard() == null)
        {
            GameManager.Instance.SetFirstCard(this);
        }
        else
        {
            GameManager.Instance.SetScondCard(this);
            GameManager.Instance.isMatched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestoryCardInvoke", 0.5f);
    }

    void DestoryCardInvoke()
    {
        Destroy(this.gameObject);
    }

    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    void CloseCardInvoke()
    {
        this.front.SetActive(false);
        this.back.SetActive(true);
    }
}
