using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using DG.Tweening;
using System.Collections;
public class Board : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject card;

    [SerializeField] List<GameObject> cards;
    [SerializeField] List<Vector3> pos;
    void Start()
    {
        int difficulty = PlayerPrefs.GetInt("SelectedDifficulty");

        int curStageNum = GameManager.Instance.curStage;

        switch (curStageNum)
        {
            case 1:
                Stage1();
                break;
            case 2:
                Stage2();
                break;
        }
    }

    void Stage1()
    {
        // 스테이지 1 배치
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
        arr = arr.OrderBy(x => Random.Range(0f, 4f)).ToArray();

        float spacing = 1.5f;

        // 상단 3x2
        for (int i = 0; i < 6; i++)
        {
            GameObject go = Instantiate(this.card, this.transform);

            int column = i % 3; // 0 1 2
            int row = i / 3;

            float x = (column - 1) * spacing;  // -1, 0, 1
            float y = (1 - row) * spacing;     // 1, 0
            go.transform.position = new Vector2(0, 4.56f);
            //go.transform.position = new Vector2(x, y);
            cards.Add(go); //오브젝트 리스트 추가
            pos.Add(new Vector3(x, y)); //좌표값 pos 리스트에 추가
            go.GetComponent<Card>().Setting(arr[i]);
        }

        // 하단 2x2
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(this.card, this.transform);

            int column = (i % 2 == 0) ? -1 : 1;
            int row = i / 2;

            float x = column * (spacing / 2);  // - spacing / 2, spacing / 2
            float y = (-1 - row) * spacing;      // -1, -2
            go.transform.position = new Vector2(0, 4.56f);
            //go.transform.position = new Vector2(x, y);
            cards.Add(go);
            pos.Add(new Vector3(x, y));
            go.GetComponent<Card>().Setting(arr[i + 6]);
        }

        GameManager.Instance.cardCount = arr.Length;
        StartCoroutine(CardMoving());
    }

    void Stage2()
    {
        int[] zeparr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 }; 
        int[] realarr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };

        List<(int, string)> cardList = new List<(int, string)>();

        foreach (int i in zeparr)
        {
            cardList.Add((i, "Zep"));
        }
        foreach (int i in realarr)
        {
            cardList.Add((i, "Real"));
        }
        cardList = cardList.OrderBy(x => Random.Range(0f, 9f)).ToList();

        float spacing = 1.4f; // 카드 간격 (원하는 만큼 조절)
        int columns = 4;
        int rows = 5;

        for (int i = 0; i < cardList.Count; i++)
        {
            GameObject go = Instantiate(this.card, this.transform); 

            int column = i % columns;
            int row = i / columns;
            float yOffset = -1.0f;

            float x = (column - (columns - 1) / 2f) * spacing;
            float y = ((rows - 1) / 2f - row) * spacing + yOffset;

            //카드 배치전 위치
            go.transform.position = new Vector2(0, 4.56f);
            //go.transform.position = new Vector2(x, y);
            cards.Add(go);
            pos.Add(new Vector3(x, y));

            var (index, type) = cardList[i];
            go.GetComponent<Card>().Setting(index, type);
        }

        GameManager.Instance.cardCount = cardList.Count;
        StartCoroutine(CardMoving());
    }

    IEnumerator CardMoving()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject go = cards[i];
            Vector3 target = pos[i];
            go.transform.DOMove(target, 0.25f);
            AudioManager.instance.Playshare();
            yield return new WaitForSeconds(0.08f);
        }
        GameManager.Instance.GameStart();
        cards.Clear();
        pos.Clear();
    }
}