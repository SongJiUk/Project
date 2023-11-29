using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : Singleton<PlayerSkill>
{

    public float Skillmul = 0;

    static float Skill1 = 1.5f;
    static float Skill2 = 2f;
    static float Skill3 = 2.5f;

    public void CheckSkillNumber(int _num)
    {
        switch(_num)
        {
            case 1:
                Skillmul = Skill1;
                break;

            case 2:
                Skillmul = Skill2;
                break;

            case 3:
                Skillmul = Skill3;
                break;
        }
    }

}
