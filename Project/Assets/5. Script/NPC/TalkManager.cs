using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitDate;

    public Sprite[] portraitSprite;

    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        portraitDate = new Dictionary<int, Sprite>();
        MakeData();
    }

    void MakeData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���" });
        talkData.Add(2000, new string[] { "ó�� ���� ���ε�", "������??" });

        portraitDate.Add(1000, portraitSprite[0]);
        portraitDate.Add(2000, portraitSprite[1]);

        talkData.Add(10 + 1000, new string[] { "�� ����", "���������� ����" });
        talkData.Add(11 + 2000, new string[] { "�� ����", "�Ұ� ����̴µ�", "�� ���� �� ã����" });

        talkData.Add(20 + 5000, new string[] { "�� �����", "�� ��ƺ�" });
        talkData.Add(21 + 2000, new string[] { "����", "���⸦ ã�ƴ޷��� �� ��ƿԾ�" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];

        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetSprite(int id)
    {
        return portraitDate[id];
    }
}
