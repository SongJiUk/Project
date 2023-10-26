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
        talkData.Add(1000, new string[] { "어서오게나", "마을을 좀 둘러봐."});
        talkData.Add(2000, new string[] { "반갑네!"});
        //talkData.Add(100, new string[] { "평범한 나무 상자다" });
        //talkData.Add(200, new string[] { "누군가 사용한적 있는 나무상자다" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "안녕하신가", "우리 마을에 잘 왔네!", "먼저 이장님을 만나보는게 어떤가?"});
        talkData.Add(10 + 2000, new string[] { "무슨일 있나?"});
        talkData.Add(11 + 2000, new string[] { "반갑네!", "난 이 마을의 이장이라네", "그런데 혹시 내 검 본적있나?", "찾으면 나에게 전해주면 고맙겠군."});

        talkData.Add(20 + 1000, new string[] { "마을은 둘러보고 있나?", "이장님의 검?", "난 잘 모르겠군."});
        talkData.Add(20 + 2000, new string[] { "검이 어디로 갔지.." });
        talkData.Add(20 + 4000, new string[] { "이장님의 검을 주웠다." });
        talkData.Add(21 + 2000, new string[] {"무슨일이지?", "아 내검을 찾아주었군!", "감사의 의미로 이걸 받아주게." });

        talkData.Add(30 + 1000, new string[] { "검을 찾았다고?", "이장님이 한시름 놓으셨겠군."});
        talkData.Add(30 + 2000, new string[] { "고맙네!" });
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
