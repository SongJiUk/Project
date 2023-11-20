using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewGameData", menuName = "QuestData", order = 1)]
public class QuestDatas : ScriptableObject
{
    public int questId;
    public int Before_NPCId;
    public int After_NPCId;

    public string goal;
    public string title;
    public string description;
    public List<ItemData> Rewarditems;
    public int Reward_Portion_Amount;
    public int Reward_Gold_Amount;
    public EQuestGoal questtype;

    public int KillCount;
}
