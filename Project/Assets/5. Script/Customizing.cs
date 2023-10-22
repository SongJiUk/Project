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

    [Header("캐릭터 장비(갑옷 등)")]
    public List<GameObject> Helmats = new List<GameObject>();

    public GameObject Female_Default_Body;
    public GameObject Female_Default_Hand;
    public GameObject Female_Default_Shoes;
    public List<GameObject> Female_Armor_Top = new List<GameObject>();
    public List<GameObject> Female_Armor_Bottom = new List<GameObject>();
    public List<GameObject> Female_hand = new List<GameObject>();
    public List<GameObject> Female_shoes = new List<GameObject>();

    public GameObject male_Default_Body;
    public GameObject male_Default_Hand;
    public GameObject male_Default_Shoes;
    public List<GameObject> male_Armor_Top = new List<GameObject>();
    public List<GameObject> male_Armor_Bottom = new List<GameObject>();
    public List<GameObject> male_hand = new List<GameObject>();
    public List<GameObject> male_Shoes = new List<GameObject>();


    [Header("UI 버튼")]
    [SerializeField] GameObject AppearanceOBJ;
    [SerializeField] GameObject ClothesOBJ;

    [SerializeField] GameObject BackBtn;
    [SerializeField] GameObject NextBtn;

    [SerializeField] GameObject CreateBtn;
    [SerializeField] GameObject SelectName_Popup;
    [SerializeField] CustomizingScene customizingscene;
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

    bool male = true;

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
    }

    float time;

    private void Update()
    {
        ////캐릭터 애니메이션
        //RandNum = Random.Range(0, 50);
        //time += Time.deltaTime;
        //if (time > 1f)
        //{
        //    time = 0;
        //    if (Selectanim != null) Selectanim.SetInteger("RandNum", RandNum);

        //}
        
     
    }
    #region 캐릭터 Select씬
    //int slotNum;
    //public void SelectSlot(int _num)
    //{
    //    gameObject.SetActive(false);

    //    slotNum = _num;
    //    //Debug.Log("DataManager : "+DataManager.GetInstance.SLOT_NUM);
    //    if(DataManager.GetInstance.ISSLOTOPEN(_num))
    //    {
    //        DataManager.GetInstance.SLOT_NUM = _num;
    //        InitPlayer(_num);
    //        gameObject.SetActive(true);

    //    }
    //    else
    //    {
    //        //여기서 생성하시겠습니까? 띄워주기
    //        Debug.Log("생성하자!!");
    //    }
    //}
    #endregion
    public void InitPlayer(int _num)
    {
        switch(DataManager.GetInstance.GENDERNUM(_num))
        {
            case 0:

                foreach(var obj in Gender)
                {
                    obj.SetActive(false);
                }
                Gender[DataManager.GetInstance.GENDERNUM(_num)].SetActive(true);

                foreach (var obj in Hair)
                {
                    obj.SetActive(false);
                }
                Hair[DataManager.GetInstance.HAIRNUM(_num)].SetActive(true);
                foreach (var obj in Female_Face)
                {
                    obj.SetActive(false);
                }
                Female_Face[DataManager.GetInstance.FEMALE_FACENUM(_num)].SetActive(true);
                foreach (var obj in Female_Eyebrow)
                {
                    obj.SetActive(false);
                }
                Female_Eyebrow[DataManager.GetInstance.FEMALE_EYEBROWNUM(_num)].SetActive(true);
                foreach (var obj in Female_Top)
                {
                    obj.SetActive(false);
                }
                Female_Top[DataManager.GetInstance.FEMALE_TOPNUM(_num)].SetActive(true);

                foreach (var obj in Female_Pants)
                {
                    obj.SetActive(false);
                }
                Female_Pants[DataManager.GetInstance.FEMALE_PANTSNUM(_num)].SetActive(true);

                break;

               
                

            case 1:

                foreach (var obj in Gender)
                {
                    obj.SetActive(false);
                }
                Gender[DataManager.GetInstance.GENDERNUM(_num)].SetActive(true);

                foreach (var obj in Hair)
                {
                    obj.SetActive(false);
                }
                Hair[DataManager.GetInstance.HAIRNUM(_num)].SetActive(true);
                foreach (var obj in male_Face)
                {
                    obj.SetActive(false);
                }
                male_Face[DataManager.GetInstance.MALE_FACENUM(_num)].SetActive(true);
                foreach (var obj in male_Eyebrow)
                {
                    obj.SetActive(false);
                }
                male_Eyebrow[DataManager.GetInstance.MALE_EYEBROWNUM(_num)].SetActive(true);
                foreach (var obj in male_Top)
                {
                    obj.SetActive(false);
                }
                male_Top[DataManager.GetInstance.MALE_TOPNUM(_num)].SetActive(true);

                foreach (var obj in male_Pants)
                {
                    obj.SetActive(false);
                }
                male_Pants[DataManager.GetInstance.MALE_PANTSNUM(_num)].SetActive(true);
                
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

    public void SelectNamePopupOn()
    {
        SelectName_Popup.SetActive(true);
    }



    public void CreateCharacter()
    {
        switch (GenderNum)
        {
            //female
            case 0:
                DataManager.GetInstance.GENDERNUM(DataManager.GetInstance.SLOT_NUM, GenderNum);
                DataManager.GetInstance.HAIRNUM(DataManager.GetInstance.SLOT_NUM, HairNum);
                DataManager.GetInstance.FEMALE_FACENUM(DataManager.GetInstance.SLOT_NUM, Female_FaceNum);
                DataManager.GetInstance.FEMALE_EYEBROWNUM(DataManager.GetInstance.SLOT_NUM, Female_EyebrowNum);
                DataManager.GetInstance.FEMALE_TOPNUM(DataManager.GetInstance.SLOT_NUM, Female_TopNum);
                DataManager.GetInstance.FEMALE_PANTSNUM(DataManager.GetInstance.SLOT_NUM, Female_PantsNum);
                break;

            //male
            case 1:
                DataManager.GetInstance.GENDERNUM(DataManager.GetInstance.SLOT_NUM, GenderNum);
                DataManager.GetInstance.HAIRNUM(DataManager.GetInstance.SLOT_NUM, HairNum);
                DataManager.GetInstance.MALE_FACENUM(DataManager.GetInstance.SLOT_NUM, male_FaceNum);
                DataManager.GetInstance.MALE_EYEBROWNUM(DataManager.GetInstance.SLOT_NUM, male_EyebrowNum);
                DataManager.GetInstance.MALE_TOPNUM(DataManager.GetInstance.SLOT_NUM, male_TopNum);
                DataManager.GetInstance.MALE_PANTSNUM(DataManager.GetInstance.SLOT_NUM, male_PantsNum);
                break;

        }

        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);


    }
    #endregion



    #region 캐릭터 장비아이템 변경

    public void ChangeEquipmentItem(EquipmentItemData _equipmnetItem)
    {                                                                                                                                       
        switch(_equipmnetItem.Gender)
        {
            case EquipmmentGender.Female:

                
                break;

            case EquipmmentGender.male:

                break;
        }
    }
    #endregion
    public void Helmate(ItemData item) 
    {
        if (item is EquipmentItemData NowItem)
        {
            List<GameObject> NowList = new List<GameObject>();
            if (NowItem.Type ==Types.Head)
            {
                NowList = Helmats;
            }
            else if(male)
            {
                if (NowItem.Type == Types.Top)
                {
                    NowList = Helmats;
                }
                else if (NowItem.Type == Types.Pants)
                {

                }
                else if (NowItem.Type == Types.Hand)
                {

                }
                else if(NowItem.Type == Types.Shoes)
                {

                }
            }
            else if(!male)
            {

            }

            for (int i = 0; i < NowList.Count; i++)
            {
                if (NowItem._EquipmentNum == NowList[i].GetComponent<PlayerEquipmentItemData>().ReturnNum())
                {
                    NowList[i].SetActive(true);
                }
                else
                {
                    NowList[i].SetActive(false);
                }
            }
        }


        




    }


}

