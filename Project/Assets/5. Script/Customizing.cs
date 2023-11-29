using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customizing : Singleton<Customizing>
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
    public List<EquipMentItemInfo> Helmats = new List<EquipMentItemInfo>();

    public GameObject Female_Default_Body;
    public GameObject Female_Default_Hand;
    public GameObject Female_Default_Shoes;
    public List<EquipMentItemInfo> Female_Armor_Top = new List<EquipMentItemInfo>();
    public List<EquipMentItemInfo> Female_Armor_Bottom = new List<EquipMentItemInfo>();
    public List<EquipMentItemInfo> Female_hand = new List<EquipMentItemInfo>();
    public List<EquipMentItemInfo> Female_shoes = new List<EquipMentItemInfo>();

    public GameObject male_Default_Body;
    public GameObject male_Default_Hand;
    public GameObject male_Default_Shoes;
    public List<EquipMentItemInfo> male_Armor_Top = new List<EquipMentItemInfo>();
    public List<EquipMentItemInfo> male_Armor_Bottom = new List<EquipMentItemInfo>();
    public List<EquipMentItemInfo> male_hand = new List<EquipMentItemInfo>();
    public List<EquipMentItemInfo> male_Shoes = new List<EquipMentItemInfo>();

    public bool isEquipHelmat = false;
    public bool isEquipTop = false;
    public bool isEquipPants = false;
    public bool isEquipHand = false;
    public bool isEquipShoes = false;
    int EquipHelmatNum;
    int EquipTopNum;
    int EquipPantsNum;
    int EquipHandNum;
    int EquipShoesNum;


    public ArmorItemData HelmatData;
    public ArmorItemData TopData;
    public ArmorItemData PantsData;
    public ArmorItemData HandData;
    public ArmorItemData ShoesData;

    
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
        //var a = EquipMentItemInfo.DATAS;
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
        switch(DataManager.GetInstance.GET_GENDERNUM(_num))
        {
            case 0:

                foreach(var obj in Gender)
                {
                    obj.SetActive(false);
                }
                Gender[DataManager.GetInstance.GET_GENDERNUM(_num)].SetActive(true);

                foreach (var obj in Hair)
                {
                    obj.SetActive(false);
                }
                Hair[DataManager.GetInstance.GET_HAIRNUM(_num)].SetActive(true);
                foreach (var obj in Female_Face)
                {
                    obj.SetActive(false);
                }
                Female_Face[DataManager.GetInstance.GET_FEMALE_FACENUM(_num)].SetActive(true);
                foreach (var obj in Female_Eyebrow)
                {
                    obj.SetActive(false);
                }
                Female_Eyebrow[DataManager.GetInstance.GET_FEMALE_EYEBROWNUM(_num)].SetActive(true);
                foreach (var obj in Female_Top)
                {
                    obj.SetActive(false);
                }
                Female_Top[DataManager.GetInstance.GET_FEMALE_TOPNUM(_num)].SetActive(true);

                foreach (var obj in Female_Pants)
                {
                    obj.SetActive(false);
                }
                Female_Pants[DataManager.GetInstance.GET_FEMALE_PANTSNUM(_num)].SetActive(true);

                Female_Default_Body.SetActive(true);
                Female_Default_Hand.SetActive(true);
                Female_Default_Shoes.SetActive(true);
                break;

               
                

            case 1:

                foreach (var obj in Gender)
                {
                    obj.SetActive(false);
                }
                Gender[DataManager.GetInstance.GET_GENDERNUM(_num)].SetActive(true);

                foreach (var obj in Hair)
                {
                    obj.SetActive(false);
                }
                Hair[DataManager.GetInstance.GET_HAIRNUM(_num)].SetActive(true);
                foreach (var obj in male_Face)
                {
                    obj.SetActive(false);
                }
                male_Face[DataManager.GetInstance.GET_MALE_FACENUM(_num)].SetActive(true);
                foreach (var obj in male_Eyebrow)
                {
                    obj.SetActive(false);
                }
                male_Eyebrow[DataManager.GetInstance.GET_MALE_EYEBROWNUM(_num)].SetActive(true);
                foreach (var obj in male_Top)
                {
                    obj.SetActive(false);
                }
                male_Top[DataManager.GetInstance.GET_MALE_TOPNUM(_num)].SetActive(true);

                foreach (var obj in male_Pants)
                {
                    obj.SetActive(false);
                }
                male_Pants[DataManager.GetInstance.GET_MALE_PANTSNUM(_num)].SetActive(true);


                male_Default_Body.SetActive(true);
                male_Default_Hand.SetActive(true);
                male_Default_Shoes.SetActive(true);
                break;

        }
    }

    public void InitEquipMentItem(int _num)
    {

        switch (DataManager.GetInstance.GET_GENDERNUM(_num))
        {
            case 0:

                if (DataManager.GetInstance.GET_ISEQUIPHELMAT(_num))
                {
                    if (DataManager.GetInstance.GET_PLAYER_JOB(_num).Equals(UnitCode.WARRIOR))
                    {
                        Female_Face[DataManager.GetInstance.GET_FEMALE_FACENUM(_num)].SetActive(false);
                    }

                    for (int i = 0; i < Helmats.Count; i++)
                    {
                        Helmats[i].gameObject.SetActive(false);
                        if (Helmats[i].DATAS.ItemCode == DataManager.GetInstance.GET_HELMATCODE(_num))
                        {
                            Helmats[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    if (DataManager.GetInstance.GET_PLAYER_JOB(_num).Equals(UnitCode.WARRIOR))
                    {
                        Female_Face[DataManager.GetInstance.GET_FEMALE_FACENUM(_num)].SetActive(true);
                    }

                    for (int i = 0; i < Helmats.Count; i++)
                    {
                        Helmats[i].gameObject.SetActive(false);
                       
                    }
                }


                if (DataManager.GetInstance.GET_ISEQUIPTOP(_num))
                {
                    Female_Top[DataManager.GetInstance.GET_FEMALE_TOPNUM(_num)].gameObject.SetActive(false);
                    
                    for (int i = 0; i < Female_Armor_Top.Count; i++)
                    {
                        Female_Armor_Top[i].gameObject.SetActive(false);
                        if (Female_Armor_Top[i].DATAS.ItemCode == DataManager.GetInstance.GET_TOPCODE(_num))
                        {
                            Female_Armor_Top[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    Female_Default_Body.SetActive(true);
                    for (int i = 0; i < Female_Armor_Top.Count; i++)
                    {
                        Female_Armor_Top[i].gameObject.SetActive(false);
                    }
                }


                if (DataManager.GetInstance.GET_ISEQUIPPANTS(_num))
                {
                    Female_Pants[DataManager.GetInstance.GET_FEMALE_PANTSNUM(_num)].gameObject.SetActive(false);
                    for (int i = 0; i < Female_Armor_Bottom.Count; i++)
                    {
                        Female_Armor_Bottom[i].gameObject.SetActive(false);
                        if (Female_Armor_Bottom[i].DATAS.ItemCode == DataManager.GetInstance.GET_PANTSCODE(_num))
                        {
                            Female_Armor_Bottom[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    Female_Pants[DataManager.GetInstance.GET_FEMALE_PANTSNUM(_num)].gameObject.SetActive(true);
                    for (int i = 0; i < Female_Armor_Bottom.Count; i++)
                    {
                        Female_Armor_Bottom[i].gameObject.SetActive(false);
                    }
                }


                if (DataManager.GetInstance.GET_ISEQUIPHAND(_num))
                {
                    Female_Default_Hand.SetActive(false);
                    for (int i = 0; i < Female_hand.Count; i++)
                    {

                        if (Female_hand[i].DATAS.ItemCode == DataManager.GetInstance.GET_HANDCODE(_num))
                        {
                            Female_hand[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    Female_Default_Hand.SetActive(true);
                    for (int i = 0; i < Female_hand.Count; i++)
                    { 
                        Female_hand[i].gameObject.SetActive(false);
                    }
                }


                if (DataManager.GetInstance.GET_ISEQUIPSHOES(_num))
                {
                    Female_Default_Shoes.SetActive(false);
                    for (int i = 0; i < Female_shoes.Count; i++)
                    {

                        if (Female_shoes[i].DATAS.ItemCode == DataManager.GetInstance.GET_SHOESCODE(_num))
                        {
                            Female_shoes[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    Female_Default_Shoes.SetActive(true);
                    for (int i = 0; i < Female_shoes.Count; i++)
                    {
                        Female_shoes[i].gameObject.SetActive(false);
                    }
                }
                break;
            case 1:

                if (DataManager.GetInstance.GET_ISEQUIPHELMAT(_num))
                {
                    if (DataManager.GetInstance.GET_PLAYER_JOB(_num).Equals(UnitCode.WARRIOR))
                    {
                        male_Face[DataManager.GetInstance.GET_MALE_FACENUM(_num)].SetActive(false);
                    }

                    for (int i = 0; i < Helmats.Count; i++)
                    {
                        Helmats[i].gameObject.SetActive(false);
                        if (Helmats[i].DATAS.ItemCode == DataManager.GetInstance.GET_HELMATCODE(_num))
                        {
                            Helmats[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }


                if (DataManager.GetInstance.GET_ISEQUIPTOP(_num))
                {
                    male_Top[DataManager.GetInstance.GET_MALE_TOPNUM(_num)].gameObject.SetActive(false);
                    male_Default_Body.SetActive(false);
                    for (int i = 0; i < male_Armor_Top.Count; i++)
                    {
                        male_Armor_Top[i].gameObject.SetActive(false);
                        if (male_Armor_Top[i].DATAS.ItemCode == DataManager.GetInstance.GET_TOPCODE(_num))
                        {
                            male_Armor_Top[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    Female_Default_Body.SetActive(true);
                    for (int i = 0; i < male_Armor_Top.Count; i++)
                    {
                        male_Armor_Top[i].gameObject.SetActive(false);
                    }
                }

                if (DataManager.GetInstance.GET_ISEQUIPPANTS(_num))
                {
                    male_Pants[DataManager.GetInstance.GET_MALE_PANTSNUM(_num)].gameObject.SetActive(false);
                    for (int i = 0; i < male_Armor_Bottom.Count; i++)
                    {
                        male_Armor_Bottom[i].gameObject.SetActive(false);
                        if (male_Armor_Bottom[i].DATAS.ItemCode == DataManager.GetInstance.GET_PANTSCODE(_num))
                        {
                            male_Armor_Bottom[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }

                if (DataManager.GetInstance.GET_ISEQUIPHAND(_num))
                {
                    male_Default_Hand.SetActive(false);
                    for (int i = 0; i < male_hand.Count; i++)
                    {
                        male_hand[i].gameObject.SetActive(false);
                        if (male_hand[i].DATAS.ItemCode == DataManager.GetInstance.GET_HANDCODE(_num))
                        {
                            male_hand[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    male_Default_Hand.SetActive(true);

                    for (int i = 0; i < male_hand.Count; i++)
                    {
                        male_hand[i].gameObject.SetActive(false);
                        
                    }

                }

                if (DataManager.GetInstance.GET_ISEQUIPSHOES(_num))
                {
                    male_Default_Shoes.SetActive(false);
                    for (int i = 0; i < male_Shoes.Count; i++)
                    {
                        male_Shoes[i].gameObject.SetActive(false);
                        if (male_Shoes[i].DATAS.ItemCode == DataManager.GetInstance.GET_SHOESCODE(_num))
                        {
                            male_Shoes[i].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    male_Default_Shoes.SetActive(true);

                    for (int i = 0; i < male_Shoes.Count; i++)
                    {
                        male_Shoes[i].gameObject.SetActive(false);
                    }
                }
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
                    customizingscene.OpenOnlyManPopup();
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
                DataManager.GetInstance.SET_GENDERNUM(DataManager.GetInstance.SLOT_NUM, GenderNum);
                DataManager.GetInstance.SET_HAIRNUM(DataManager.GetInstance.SLOT_NUM, HairNum);
                DataManager.GetInstance.SET_FEMALE_FACENUM(DataManager.GetInstance.SLOT_NUM, Female_FaceNum);
                DataManager.GetInstance.SET_FEMALE_EYEBROWNUM(DataManager.GetInstance.SLOT_NUM, Female_EyebrowNum);
                DataManager.GetInstance.SET_FEMALE_TOPNUM(DataManager.GetInstance.SLOT_NUM, Female_TopNum);
                DataManager.GetInstance.SET_FEMALE_PANTSNUM(DataManager.GetInstance.SLOT_NUM, Female_PantsNum);
                break;                 
                                       
            //male                     
            case 1:                    
                DataManager.GetInstance.SET_GENDERNUM(DataManager.GetInstance.SLOT_NUM, GenderNum);
                DataManager.GetInstance.SET_HAIRNUM(DataManager.GetInstance.SLOT_NUM, HairNum);
                DataManager.GetInstance.SET_MALE_FACENUM(DataManager.GetInstance.SLOT_NUM, male_FaceNum);
                DataManager.GetInstance.SET_MALE_EYEBROWNUM(DataManager.GetInstance.SLOT_NUM, male_EyebrowNum);
                DataManager.GetInstance.SET_MALE_TOPNUM(DataManager.GetInstance.SLOT_NUM, male_TopNum);
                DataManager.GetInstance.SET_MALE_PANTSNUM(DataManager.GetInstance.SLOT_NUM, male_PantsNum);
                break;

        }
        DataManager.GetInstance.SET_PLAYER_LEVEL(DataManager.GetInstance.SLOT_NUM, 1);

        //초반 캐릭터 스탯 확인
        DataManager.GetInstance.SET_QUEST_ID(DataManager.GetInstance.SLOT_NUM, 10);
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);


    }
    #endregion



    #region 캐릭터 장비아이템 변경

    public int ChangeEquipmentItem(ArmorItemData _equipmnetItem)
   {
        //if (_equipmnetItem == null)
        //{
        //    // 오른쪽 클릭해서 장착 해제할 때
        //    return ;
        //}

        // 필요한 데이터 가져오기
        int slotGender = DataManager.GetInstance.GET_GENDERNUM(DataManager.GetInstance.SLOT_NUM);
        int playerJob = DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM);
        int playerLevel = PlayerStat.GetInstance.Level;
        int equipGender = (int)_equipmnetItem.Gender;
        int equipClassPrivateItem = (int)_equipmnetItem.ClassPrivateItem;
        int equipLevel = _equipmnetItem._EquipmentLevel;

        //공용 아이템
        if (equipGender == 2) equipGender = slotGender;
        // 직업 체크
        if (!playerJob.Equals(equipClassPrivateItem))
        {
            // 직업이 맞지 않음 UI
            Debug.Log("Diffrent Job");
            return 3;
        }

        // 성별 체크
        if (!slotGender.Equals(equipGender))
        {
            // 성별이 맞지 않음 UI
            Debug.Log("Diffrent Gender");
            return 2;
        }

        //레벨 체크
        if (playerLevel < equipLevel)
        {
            // 레벨이 부족 UI
            Debug.Log("Low Level");
            return 1;
        }

       
        

        // 아이템 타입에 따라 장비 교체
        switch (_equipmnetItem.Type)
        {
            case Types.Head:
                ChangeHead(_equipmnetItem);
                break;
            case Types.Top:
                ChangeTop(_equipmnetItem);
                break;
            case Types.Pants:
                ChangePants(_equipmnetItem);
                break;
            case Types.Hand:
                ChangeHands(_equipmnetItem);
                break;
            case Types.Shoes:
                ChangeShoes(_equipmnetItem);
                break;
        }
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);
        return 0;
    }

    public void ChangeDefault(int _num)
    {
        int slotNum = DataManager.GetInstance.SLOT_NUM;
        switch (_num)
        {
            //top
            case 1:
                //여자
                if(DataManager.GetInstance.GET_GENDERNUM(slotNum) == 0)
                {
                    int index = FindItemIndex(Female_Armor_Top, DataManager.GetInstance.GET_TOPCODE(slotNum));
                    Female_Armor_Top[index].gameObject.SetActive(false);
                    Female_Top[DataManager.GetInstance.GET_FEMALE_TOPNUM(slotNum)].SetActive(true);
                    Female_Default_Body.SetActive(true);
                }
                //남자
                else
                {
                    int index = FindItemIndex(male_Armor_Top, DataManager.GetInstance.GET_TOPCODE(slotNum));
                    male_Armor_Top[index].gameObject.SetActive(false);
                    male_Top[DataManager.GetInstance.GET_MALE_TOPNUM(slotNum)].SetActive(true);
                    male_Default_Body.SetActive(true);
                }

                break;

            //pants
            case 2:
                //여자
                if (DataManager.GetInstance.GET_GENDERNUM(slotNum) == 0)
                {
                    int index = FindItemIndex(Female_Armor_Bottom, DataManager.GetInstance.GET_PANTSCODE(slotNum));
                    Female_Armor_Bottom[index].gameObject.SetActive(false);
                    Female_Pants[DataManager.GetInstance.GET_FEMALE_PANTSNUM(slotNum)].SetActive(true);
                }
                //남자
                else
                {
                    int index = FindItemIndex(male_Armor_Bottom, DataManager.GetInstance.GET_PANTSCODE(slotNum));
                    male_Armor_Bottom[index].gameObject.SetActive(false);
                    male_Pants[DataManager.GetInstance.GET_MALE_PANTSNUM(slotNum)].SetActive(true);
                }
                break;

            //head
            case 3:

                //공용 
                Helmats[FindItemIndex(Helmats, DataManager.GetInstance.GET_HELMATCODE(slotNum))]
                    .gameObject.SetActive(false);
                Hair[DataManager.GetInstance.GET_HAIRNUM(slotNum)].SetActive(true);

                break;

            //hand
            case 4:
                //여자
                if (DataManager.GetInstance.GET_GENDERNUM(slotNum) == 0)
                {
                    int index = FindItemIndex(Female_hand, DataManager.GetInstance.GET_HANDCODE(slotNum));
                    Female_hand[index].gameObject.SetActive(false);
                    Female_Default_Hand.SetActive(true);
                }
                //남자
                else
                {
                    int index = FindItemIndex(male_Armor_Top, DataManager.GetInstance.GET_HANDCODE(slotNum));
                    male_hand[index].gameObject.SetActive(false);
                    male_Default_Hand.SetActive(true);
                }
                break;

            //shoes
            case 5:
                //여자
                if (DataManager.GetInstance.GET_GENDERNUM(slotNum) == 0)
                {
                    int index = FindItemIndex(Female_Armor_Top, DataManager.GetInstance.GET_SHOESCODE(slotNum));
                    Female_shoes[index].gameObject.SetActive(false);
                    Female_Default_Shoes.SetActive(true);
                }
                //남자
                else
                {
                    int index = FindItemIndex(male_Armor_Top, DataManager.GetInstance.GET_SHOESCODE(slotNum));
                    male_Shoes[index].gameObject.SetActive(false);
                    male_Default_Shoes.SetActive(true);
                }
                break;


        }
    }

    public int FindItemIndex(List<EquipMentItemInfo> _item, int _itemCode)
    {
        for(int i=0; i<_item.Count; i++)
        {
            if(_item[i].DATAS.ItemCode.Equals(_itemCode))
            {
                return i;
            }
        }
        return 0;
    }

    void ChangeHead(ArmorItemData _equipmentItem)
    {
        //장착 되어있을때 교체
        if (isEquipHelmat)
        {
            PlayerStat.GetInstance.ChangeStat(HelmatData, _equipmentItem);
            Helmats[EquipHelmatNum].gameObject.SetActive(false);
        }
        else //아니면 그냥 장착
        {
            PlayerStat.GetInstance.ChangeStat(_equipmentItem);
        }

        // 장비 교체
        Hair[DataManager.GetInstance.GET_HAIRNUM(DataManager.GetInstance.SLOT_NUM)].SetActive(false);

        EquipHelmatNum = FindItemIndex(Helmats, _equipmentItem.ItemCode);
        Helmats[EquipHelmatNum].gameObject.SetActive(true);
        HelmatData = _equipmentItem;
        isEquipHelmat = true;
    }

    void ChangeTop(ArmorItemData _equipmentItem)
    {

        switch(_equipmentItem.Gender)
        {
            case EquipmmentGender.Female:

                if (isEquipTop)
                {
                    PlayerStat.GetInstance.ChangeStat(TopData, _equipmentItem);
                    Female_Armor_Top[EquipTopNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipTopNum = FindItemIndex(Female_Armor_Top, _equipmentItem.ItemCode);
                Female_Armor_Top[EquipTopNum].gameObject.SetActive(true);
                Female_Default_Body.SetActive(false);
                TopData = _equipmentItem;
                isEquipTop = true;
                break;

            case EquipmmentGender.male:
                if (isEquipTop)
                {
                    PlayerStat.GetInstance.ChangeStat(TopData, _equipmentItem);
                    male_Armor_Top[EquipTopNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipTopNum = FindItemIndex(male_Armor_Top, _equipmentItem.ItemCode);
                male_Armor_Top[EquipTopNum].gameObject.SetActive(true);
                male_Default_Body.SetActive(false);
                TopData = _equipmentItem;
                isEquipTop = true;
                break;
        }
        
    }


    void ChangePants(ArmorItemData _equipmentItem)
    {

        switch (_equipmentItem.Gender)
        {
            case EquipmmentGender.Female:
                if (isEquipPants)
                {
                    PlayerStat.GetInstance.ChangeStat(PantsData, _equipmentItem);
                    Female_Armor_Bottom[EquipPantsNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipPantsNum = FindItemIndex(Female_Armor_Bottom, _equipmentItem.ItemCode);
                Female_Armor_Bottom[EquipPantsNum].gameObject.SetActive(true);
                PantsData = _equipmentItem;
                isEquipPants = true;
                break;

            case EquipmmentGender.male:
                if (isEquipPants)
                {
                    PlayerStat.GetInstance.ChangeStat(PantsData, _equipmentItem);
                    male_Armor_Bottom[EquipPantsNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipPantsNum = FindItemIndex(male_Armor_Bottom, _equipmentItem.ItemCode);
                male_Armor_Bottom[EquipPantsNum].gameObject.SetActive(true);
                PantsData = _equipmentItem;
                isEquipPants = true;
                break;
        }

    }

    void ChangeHands(ArmorItemData _equipmentItem)
    {

        switch (_equipmentItem.Gender)
        {
            case EquipmmentGender.Female:
                if (isEquipHand)
                {
                    PlayerStat.GetInstance.ChangeStat(HandData, _equipmentItem);
                    Female_hand[EquipHandNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipHandNum = FindItemIndex(Female_hand, _equipmentItem.ItemCode);
                Female_hand[EquipHandNum].gameObject.SetActive(true);
                Female_Default_Hand.SetActive(false);
                HandData = _equipmentItem;
                isEquipHand = true;
                break;

            case EquipmmentGender.male:
                if (isEquipHand)
                {
                    PlayerStat.GetInstance.ChangeStat(HandData, _equipmentItem);
                    male_hand[EquipHandNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipHandNum = FindItemIndex(male_hand, _equipmentItem.ItemCode);
                male_hand[EquipHandNum].gameObject.SetActive(true);
                male_Default_Hand.SetActive(false);
                HandData = _equipmentItem;
                isEquipHand = true;
                break;
        }

    }

    void ChangeShoes(ArmorItemData _equipmentItem)
    {

        switch (_equipmentItem.Gender)
        {
            case EquipmmentGender.Female:
                if (isEquipShoes)
                {
                    PlayerStat.GetInstance.ChangeStat(ShoesData, _equipmentItem);
                    Female_shoes[EquipShoesNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipShoesNum = FindItemIndex(Female_shoes, _equipmentItem.ItemCode);
                Female_shoes[EquipShoesNum].gameObject.SetActive(true);
                Female_Default_Shoes.SetActive(false);
                ShoesData = _equipmentItem;
                isEquipShoes = true;

                break;

            case EquipmmentGender.male:
                if (isEquipShoes)
                {
                    PlayerStat.GetInstance.ChangeStat(ShoesData, _equipmentItem);
                    male_Shoes[EquipShoesNum].gameObject.SetActive(false);
                }
                else //아니면 그냥 장착
                {
                    PlayerStat.GetInstance.ChangeStat(_equipmentItem);
                }

                // 장비 교체
                EquipShoesNum = FindItemIndex(male_Shoes, _equipmentItem.ItemCode);
                male_Shoes[EquipShoesNum].gameObject.SetActive(true);
                male_Default_Shoes.SetActive(false);
                ShoesData = _equipmentItem;
                isEquipShoes = true;

                break;
        }

    }
    


    #endregion
    //public void Helmate(ItemData item) 
    //{
    //    if (item is EquipmentItemData NowItem)
    //    {
    //        List<GameObject> NowList = new List<GameObject>();
    //        if (NowItem.Type ==Types.Head)
    //        {
    //            NowList = Helmats;
    //        }
    //        else if(male)
    //        {
    //            if (NowItem.Type == Types.Top)
    //            {
    //                NowList = Helmats;
    //            }
    //            else if (NowItem.Type == Types.Pants)
    //            {

    //            }
    //            else if (NowItem.Type == Types.Hand)
    //            {

    //            }
    //            else if(NowItem.Type == Types.Shoes)
    //            {

    //            }
    //        }
    //        else if(!male)
    //        {

    //        }

    //        for (int i = 0; i < NowList.Count; i++)
    //        {
    //            if (NowItem._EquipmentNum == NowList[i].GetComponent<PlayerEquipmentItemData>().ReturnNum())
    //            {
    //                NowList[i].SetActive(true);
    //            }
    //            else
    //            {
    //                NowList[i].SetActive(false);
    //            }
    //        }
    //    }







    //}


}

