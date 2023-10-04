using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GeneratorData();
    }

    void GeneratorData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?", "�̰��� ó�� �Ա���?", "�ѹ� �ѷ����� ��." });
        talkData.Add(2000, new string[] { "����?", "�ʵ� ������ �븮�°ų�"});
        //talkData.Add(100, new string[] { "����� ���� ���ڴ�" });
        //talkData.Add(200, new string[] { "������ ������� �ִ� �������ڴ�" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "� ��!", "�̸����� ���� ������ �ִٴµ�", "���� ���� ģ������ �����." });
        talkData.Add(10 + 2000, new string[] { "�� ������."});
        talkData.Add(11 + 2000, new string[] { "����", "�ʵ� ������ ���� �˰� �����ų�?", "������ ��¥�δ� �ȵ���", "Ǯ���� �� �������� �˷��ٰ�." });

        talkData.Add(20 + 1000, new string[] { "�ȳ�!", "Ǯ���� ��ġ?", "���� ���������� ���� �־����� ����!"});
        talkData.Add(20 + 2000, new string[] { "Ǯ���� ������." });
        talkData.Add(20 + 4000, new string[] { "Ǯ���� �ֿ���." });
        talkData.Add(21 + 2000, new string[] {"�� Ǯ�����ݾ�?", "�� �������� ������ ������ �ִٰ� �����.", "���� ���̴� ���� �ִٰ� ������ ������." });

        talkData.Add(30 + 1000, new string[] { "�ȳ�!", "���� ���?", "�� ���ȴ�!" });
        talkData.Add(30 + 2000, new string[] { "������.. ������ �ִ����� ���� ����." });
    }

    public string GetTalk(int id, int talkindex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (talkindex == talkData[id - id % 10].Length)
            {
                return GetTalk(id - id % 100, talkindex);
            } 
            else
            {
                return GetTalk(id - id % 10, talkindex);
            }
        }

        if (talkindex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkindex];
    }

}
