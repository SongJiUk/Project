using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customizing : MonoBehaviour
{
    public List<GameObject> Gender = new List<GameObject>();
    public List<GameObject> Hair = new List<GameObject>();
    public List<GameObject> Female_Face = new List<GameObject>();
    public List<GameObject> Female_Eyebrow = new List<GameObject>();
    public List<GameObject> male_Face = new List<GameObject>();
    public List<GameObject> male_Eyebrow = new List<GameObject>();
    public List<GameObject> male_Mustache = new List<GameObject>();
    
    
    int GenderNum;
    int HairNum;
    int Female_FaceNum;
    int male_FaceNum;
    int Female_EyebrowNum;
    int male_EyebrowNum;
    int MustacheNum;
    Coroutine myCoruotine;

    private void Awake()
    {
        GenderNum = 0;
        HairNum = 0;
        Female_FaceNum = 0;
        male_FaceNum = 0;
        Female_EyebrowNum = 0;
        male_EyebrowNum = 0;
        MustacheNum = 0;
    }
    public void ChangeCustomizingPrev(int _num)
    {
        switch(_num)
        {
            //Gender 0 - Female, 1 - Male
            case 0:
                Gender[GenderNum--].SetActive(false);
                if (GenderNum < 0) GenderNum = Gender.Count -1;
                Gender[GenderNum].SetActive(true);
                break;

            //Hair
            case 1:
                Hair[HairNum--].SetActive(false);
                if (HairNum < 0) HairNum = Hair.Count - 1;
                Hair[HairNum].SetActive(true);
                break;

            //Face
            case 2:

                if (GenderNum.Equals(0))
                {
                    Female_Face[Female_FaceNum--].SetActive(false);
                    if (Female_FaceNum < 0) Female_FaceNum = Female_Face.Count - 1;
                    Female_Face[Female_FaceNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Face[male_FaceNum--].SetActive(false);
                    if (male_FaceNum < 0) male_FaceNum = male_Face.Count - 1;
                    male_Face[male_FaceNum].SetActive(true);
                }
                break;

            //Eyebrow
            case 3:

                if (GenderNum.Equals(0))
                {
                    Female_Eyebrow[Female_EyebrowNum--].SetActive(false);
                    if (Female_EyebrowNum < 0) Female_EyebrowNum = Female_Eyebrow.Count - 1;
                    Female_Eyebrow[Female_EyebrowNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Eyebrow[male_EyebrowNum--].SetActive(false);
                    if (male_EyebrowNum < 0) male_EyebrowNum = male_Eyebrow.Count - 1;
                    male_Eyebrow[male_EyebrowNum].SetActive(true);
                }
                break;

            //Mustache
            case 4:

                if (GenderNum.Equals(0))
                {
                    Debug.Log("남자 전용입니다.");
                }
                else if (GenderNum.Equals(1))
                {
                    male_Mustache[MustacheNum--].SetActive(false);
                    if (MustacheNum < 0) MustacheNum = male_Mustache.Count - 1;
                    male_Mustache[MustacheNum].SetActive(true);
                }
                break;

        }
    }

    public void ChangeCustomizingNext(int _num)
    {
        switch (_num)
        {
            case 0:
                Gender[GenderNum++].SetActive(false);
                if (GenderNum > Gender.Count-1) GenderNum = 0;
                Gender[GenderNum].SetActive(true);
                break;

            case 1:
                Hair[HairNum++].SetActive(false);
                if (HairNum > Hair.Count - 1) HairNum = 0;
                Hair[HairNum].SetActive(true);
                break;

            case 2:

                if(GenderNum.Equals(0))
                { 
                    Female_Face[Female_FaceNum++].SetActive(false);
                    if (Female_FaceNum > Female_Face.Count - 1) Female_FaceNum = 0;
                    Female_Face[Female_FaceNum].SetActive(true);
                }
                else if(GenderNum.Equals(1))
                {
                    male_Face[male_FaceNum++].SetActive(false);
                    if (male_FaceNum > male_Face.Count - 1) male_FaceNum = 0;
                    male_Face[male_FaceNum].SetActive(true);
                }
                break;

            case 3:

                if (GenderNum.Equals(0))
                {
                    Female_Eyebrow[Female_EyebrowNum++].SetActive(false);
                    if (Female_EyebrowNum > Female_Eyebrow.Count - 1) Female_EyebrowNum = 0;
                    Female_Eyebrow[Female_EyebrowNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Eyebrow[male_EyebrowNum++].SetActive(false);
                    if (male_EyebrowNum > male_Eyebrow.Count - 1) male_EyebrowNum = 0;
                    male_Eyebrow[male_EyebrowNum].SetActive(true);
                }
                break;

            case 4:

                if (GenderNum.Equals(0))
                {
                    Debug.Log("남자 전용입니다.");
                }
                else if (GenderNum.Equals(1))
                {
                    male_Mustache[MustacheNum++].SetActive(false);
                    if (MustacheNum > male_Mustache.Count - 1) MustacheNum = 0;
                    male_Mustache[MustacheNum].SetActive(true);
                }
                break;

        }
    }



    #region 캐릭터 회전
    public void TurnCharacter(bool _isRight)
    {
        if(_isRight) myCoruotine = StartCoroutine(CharacterTurn(_isRight));
        else myCoruotine = StartCoroutine(CharacterTurn(_isRight));
    }


    public void StopTurn()
    {
        StopCoroutine(myCoruotine);
    }

    IEnumerator CharacterTurn(bool _isright)
    {
        while(true)
        {
            yield return null;

            if(_isright)
            {
                transform.Rotate(Vector3.down);
            }
            else
            {
                transform.Rotate(Vector3.up);
            }

        }
    }
    #endregion


    public void CreateCharacter()
    {

    }
}
