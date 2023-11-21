using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_NPCUP : MonoBehaviour
{

    [SerializeField] GameObject[] NPCICON;


    public void ClearQuest()
    {
        NPCICON[0].SetActive(true);
        NPCICON[1].SetActive(false);
        NPCICON[2].SetActive(false);
    }

    public void NOAcceptQuest()
    {
        NPCICON[0].SetActive(false);
        NPCICON[1].SetActive(true);
        NPCICON[2].SetActive(false);
    }

    public void IsQuesting()
    {
        NPCICON[0].SetActive(false);
        NPCICON[1].SetActive(false);
        NPCICON[2].SetActive(true);
    }

    public void ALLCLEAR()
    {
        NPCICON[0].SetActive(false);
        NPCICON[1].SetActive(false);
        NPCICON[2].SetActive(false);
    }
}
