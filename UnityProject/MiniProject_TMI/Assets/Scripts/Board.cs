using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Board : MonoBehaviour
{
    [SerializeField] Transform cards;
    [SerializeField] GameObject card;

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

            go.transform.position = new Vector2(x, y);
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

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i + 6]);
        }

        GameManager.Instance.cardCount = arr.Length;
    }

    void Stage2()
    {
        int[] zeparr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 }; //@ 김재영 리얼 카드 이미지를 사용하기 위해 이 부분 수정
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
            GameObject go = Instantiate(this.card, cards); // @김재영 스테이지 1과 2가 동일학게 배치되서 수정.

            int column = i % columns;
            int row = i / columns;
            float yOffset = -1.0f;

            float x = (column - (columns - 1) / 2f) * spacing;
            float y = ((rows - 1) / 2f - row) * spacing + yOffset; // @김재영 중앙 배치를 하게되면 카드가 시간을 가려서 전체적인 y 좌표를 아래로 내림.

            go.transform.position = new Vector2(x, y);

            var (index, type) = cardList[i];
            go.GetComponent<Card>().Setting(index, type);
        }

        GameManager.Instance.cardCount = cardList.Count;
    }
}