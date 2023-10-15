using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customizing : MonoBehaviour
{
    [Header("캐릭터 커스터마이징")]
    public List<GameObject> Gender = new List<GameObject>();
    public List<GameObject> Hair = new List<GameObject>();
    public List<GameObject> Female_Face = new List<GameObject>();
    public List<GameObject> Female_Eyebrow = new List<GameObject>();
    public List<GameObject> male_Face = new List<GameObject>();
    public List<GameObject> male_Eyebrow = new List<GameObject>();
    public List<GameObject> male_Mustache = new List<GameObject>();
    public List<GameObject> Female_Top = new List<GameObject>();
    public List<GameObject> Female_Pants = new List<GameObject>();
    public List<GameObject> male_Top = new List<GameObject>();
    public List<GameObject> male_Pants = new List<GameObject>();

    [Header("UI 버튼")]
    [SerializeField] GameObject AppearanceOBJ;
    [SerializeField] GameObject ClothesOBJ;

    [SerializeField] GameObject BackBtn;
    [SerializeField] GameObject NextBtn;

    [SerializeField] GameObject CreateBtn;


    Animator Selectanim;
    int RandNum;

    int GenderNum;
    int HairNum;
    int Female_FaceNum;
    int male_FaceNum;
    int Female_EyebrowNum;
    int male_EyebrowNum;
    int MustacheNum;
    int Female_TopNum;
    int Female_PantsNum;
    int male_TopNum;
    int male_PantsNum;

    List<int> playerInfo = new List<int>();
    Dictionary<string, List<int>> PlayerInfoDic = new Dictionary<string, List<int>>();
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
        Female_TopNum = 0;
        Female_PantsNum = 0;
        male_TopNum = 0;
        male_PantsNum = 0;
        if (null == Selectanim) Selectanim = GetComponent<Animator>();
        DataManager.GetInstance.LoadData();
    }

    float time;

    private void Update()
    {
        RandNum = Random.Range(0, 50);
        time += Time.deltaTime;
        if (time > 1f)
        {
            time = 0;
            if (Selectanim != null) Selectanim.SetInteger("RandNum", RandNum);

        }
        
    }

    public void InitPlayer()
    {
        switch(GenderNum)
        {
            case 0:

                foreach(var obj in Gender)
                {
                    obj.SetActive(false);
                }
                Gender[DataManager.GetInstance.GENDERNUM].SetActive(true);

                foreach (var obj in Hair)
                {
                    obj.SetActive(false);
                }
                Hair[DataManager.GetInstance.HAIRNUM].SetActive(true);
                foreach (var obj in Female_Face)
                {
                    obj.SetActive(false);
                }
                Female_Face[DataManager.GetInstance.FEMALE_FACENUM].SetActive(true);
                foreach (var obj in Female_Eyebrow)
                {
                    obj.SetActive(false);
                }
                Female_Eyebrow[DataManager.GetInstance.FEMALE_EYEBROWNUM].SetActive(true);
                foreach (var obj in Female_Top)
                {
                    obj.SetActive(false);
                }
                Female_Top[DataManager.GetInstance.FEMALE_TOPNUM].SetActive(true);

                foreach (var obj in Female_Pants)
                {
                    obj.SetActive(false);
                }
                Female_Pants[DataManager.GetInstance.FEMALE_PANTSNUM].SetActive(true);

                break;

               
                

            case 1:

                foreach (var obj in Gender)
                {
                    obj.SetActive(false);
                }
                Gender[DataManager.GetInstance.GENDERNUM].SetActive(true);

                foreach (var obj in Hair)
                {
                    obj.SetActive(false);
                }
                Hair[DataManager.GetInstance.HAIRNUM].SetActive(true);
                foreach (var obj in male_Face)
                {
                    obj.SetActive(false);
                }
                male_Face[DataManager.GetInstance.MALE_FACENUM].SetActive(true);
                foreach (var obj in male_Eyebrow)
                {
                    obj.SetActive(false);
                }
                male_Eyebrow[DataManager.GetInstance.MALE_EYEBROWNUM].SetActive(true);
                foreach (var obj in male_Top)
                {
                    obj.SetActive(false);
                }
                male_Top[DataManager.GetInstance.MALE_TOPNUM].SetActive(true);

                foreach (var obj in male_Pants)
                {
                    obj.SetActive(false);
                }
                male_Pants[DataManager.GetInstance.MALE_PANTSNUM].SetActive(true);
                
                break;

        }
    }

    #region 선택창 
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

            //Top
            case 5:
                if (GenderNum.Equals(0))
                {
                    Female_Top[Female_TopNum--].SetActive(false);
                    if (Female_TopNum < 0) Female_TopNum = Female_Top.Count - 1;
                    Female_Top[Female_TopNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Top[male_TopNum--].SetActive(false);
                    if (male_TopNum < 0) male_TopNum = male_Top.Count - 1;
                    male_Top[male_TopNum].SetActive(true);
                }
                break;

            //Pants
            case 6:
                if (GenderNum.Equals(0))
                {
                    Female_Pants[Female_PantsNum--].SetActive(false);
                    if (Female_PantsNum < 0) Female_PantsNum = Female_Pants.Count - 1;
                    Female_Pants[Female_PantsNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Pants[male_PantsNum--].SetActive(false);
                    if (male_PantsNum < 0) male_PantsNum = male_Pants.Count - 1;
                    male_Pants[male_PantsNum].SetActive(true);
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

            //Top
            case 5:
                if (GenderNum.Equals(0))
                {
                    Female_Top[Female_TopNum++].SetActive(false);
                    if (Female_TopNum > Female_Top.Count - 1) Female_TopNum = 0;
                    Female_Top[Female_TopNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Top[male_TopNum++].SetActive(false);
                    if (male_TopNum > male_Top.Count - 1) male_TopNum = 0;
                    male_Top[male_TopNum].SetActive(true);
                }
                break;

            //Pants
            case 6:
                if (GenderNum.Equals(0))
                {
                    Female_Pants[Female_PantsNum++].SetActive(false);
                    if (Female_PantsNum > Female_Pants.Count - 1) Female_PantsNum = 0;
                    Female_Pants[Female_PantsNum].SetActive(true);
                }
                else if (GenderNum.Equals(1))
                {
                    male_Pants[male_PantsNum++].SetActive(false);
                    if (male_PantsNum > male_Pants.Count - 1) male_PantsNum = 0;
                    male_Pants[male_PantsNum].SetActive(true);
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

    public void Back_Appearance()
    {
        AppearanceOBJ.SetActive(true);
        ClothesOBJ.SetActive(false);
        BackBtn.SetActive(false);
        NextBtn.SetActive(true);

        CreateBtn.SetActive(false);
    }   

    public void Select_Over_Appearance()
    {
        AppearanceOBJ.SetActive(false);
        ClothesOBJ.SetActive(true);
        BackBtn.SetActive(true);
        NextBtn.SetActive(false);

        CreateBtn.SetActive(true);
    }

    public void CreateCharacter()
    {

        switch(GenderNum)
        {
            //female
            case 0:
                DataManager.GetInstance.HAIRNUM = HairNum;
                DataManager.GetInstance.FEMALE_FACENUM = Female_FaceNum;
                DataManager.GetInstance.FEMALE_EYEBROWNUM = Female_EyebrowNum;
                DataManager.GetInstance.FEMALE_TOPNUM = Female_TopNum;
                DataManager.GetInstance.FEMALE_PANTSNUM = Female_PantsNum;
                break;

                //male
            case 1:
                DataManager.GetInstance.HAIRNUM = HairNum;
                DataManager.GetInstance.MALE_FACENUM = male_FaceNum;
                DataManager.GetInstance.MALE_EYEBROWNUM = male_EyebrowNum;
                DataManager.GetInstance.MALE_TOPNUM = male_TopNum;
                DataManager.GetInstance.MALE_PANTSNUM = male_PantsNum;
                break;

        }

        DataManager.GetInstance.SaveData();

        var operation = SceneManager.LoadSceneAsync("Song");
        operation.allowSceneActivation = true;
    }
    #endregion
}

