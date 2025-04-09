using UnityEngine;

public class Card : MonoBehaviour
{
    public int index = 0;

    [Header("Genaral")]
    [SerializeField] GameObject front;
    [SerializeField] GameObject back;

    [SerializeField] Animator anim;

    [SerializeField] SpriteRenderer frontImage;

    public void Setting(int number)  // @김재영 스테이지 2의 이미지 배치를 위해 타입 추가 
    {   
        this.index = number;
        this.frontImage.sprite = Resources.Load<Sprite>($"Member{index}_zep"); 
    }

    public void Setting(int number, string type)  // @김재영 스테이지 2용 추가
    {
        this.index = number;
        this.frontImage.sprite = Resources.Load<Sprite>($"Member{index}_{type}");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);

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
    public void OpenCardanim()
    {
        this.front.SetActive(true);
        this.back.SetActive(false);
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
        anim.SetBool("isClose", true);
    }
    public void CloseCardAnim()
    {
        this.front.SetActive(false);
        this.back.SetActive(true);
        anim.SetBool("isClose", false);
        anim.SetBool("isOpen", false);
    }
}
