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
        talkData.Add(1000, new string[] { "안녕?", "이곳에 처음 왔구나?", "한번 둘러보록 해." });
        talkData.Add(2000, new string[] { "여어?", "너도 보물을 노리는거냐"});
        //talkData.Add(100, new string[] { "평범한 나무 상자다" });
        //talkData.Add(200, new string[] { "누군가 사용한적 있는 나무상자다" });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서 와!", "이마을에 놀라운 전설이 있다는데", "저기 옆에 친구한태 물어봐." });
        talkData.Add(10 + 2000, new string[] { "넌 누구야."});
        talkData.Add(11 + 2000, new string[] { "어이", "너도 전설에 대해 알고 싶은거냐?", "하지만 꽁짜로는 안되지", "풀잎을 좀 가져오면 알려줄게." });

        talkData.Add(20 + 1000, new string[] { "안녕!", "풀잎의 위치?", "저기 오른쪽으로 가면 있었던거 같아!"});
        talkData.Add(20 + 2000, new string[] { "풀잎을 가져와." });
        talkData.Add(20 + 4000, new string[] { "풀잎을 주웠다." });
        talkData.Add(21 + 2000, new string[] {"오 풀잎이잖아?", "이 마을에는 전설의 보물이 있다고 들었어.", "저기 보이는 성에 있다고 들은거 같은데." });

        talkData.Add(30 + 1000, new string[] { "안녕!", "성의 비밀?", "좀 기대된다!" });
        talkData.Add(30 + 2000, new string[] { "조심해.. 무엇이 있는지는 나도 몰라." });
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
