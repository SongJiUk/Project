using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{

    [SerializeField] List<WeaponItemData> WeaponLists = new List<WeaponItemData>();

    Dictionary<string, WeaponItemData> WeaponData = new Dictionary<string, WeaponItemData>();

    [SerializeField] List<ArmorItemData> ArmorLists = new List<ArmorItemData>();
    Dictionary<string, ArmorItemData> ArmorData = new Dictionary<string, ArmorItemData>();

    [SerializeField] List<PortionItemData> PortionLists = new List<PortionItemData>();
    Dictionary<string, PortionItemData> PortionData = new Dictionary<string, PortionItemData>();


    [SerializeField] List<ItemData> Goldlists = new List<ItemData>();
    Dictionary<string, ItemData> GoldData = new Dictionary<string, ItemData>();
    public List<Item> items;

    private void Awake()
    {
        for (int i = 0; i < WeaponLists.Count; i++)
        {
            if (WeaponLists[i] != null)
            {
                WeaponData.Add(WeaponLists[i].ItemCodeName, WeaponLists[i]);
            }
        }

        for (int i = 0; i < ArmorLists.Count; i++)
        {
            if (ArmorLists[i] != null)
            {
                ArmorData.Add(ArmorLists[i].ItemCodeName, ArmorLists[i]);
            }
        }

        for (int i = 0; i < PortionLists.Count; i++)
        {
            if (PortionLists[i] != null)
            {
                PortionData.Add(PortionLists[i].ItemCodeName, PortionLists[i]);
            }
        }

        for(int i =0; i< Goldlists.Count; i++)
        {
            if(Goldlists[i] != null)
            {
                GoldData.Add(Goldlists[i].ItemCodeName, Goldlists[i]);
            }
        }

        //DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //WeaponManager.GetInstance.ChangeWeapon(WeaponData["Hand"]);
    }

    public WeaponItemData GetWeaponData(string _name)
    {
        if(WeaponData.ContainsKey(_name))
        {
            return WeaponData[_name];
        }

        return null;
    }


    public ArmorItemData GetArmorData(string _name)
    {
        if (ArmorData.ContainsKey(_name))
        {
            return ArmorData[_name];
        }

        return null;
    }

    public PortionItemData GetPortionData(string _name)
    {
        if (PortionData.ContainsKey(_name))
        {
            return PortionData[_name];
        }
        return null;
    }

    public ItemData GetGoldData(string _name)
    {
        if(GoldData.ContainsKey(_name))
        {
            return GoldData[_name];
        }
        return null;
    }

    public WeaponItemData GetWeaponItemData(int _value)
    {
        for(int i =0; i<WeaponLists.Count; i++)
        {
            if (WeaponLists[i].ItemCode == _value)
            {
                return WeaponLists[i];
            }
        }
        return null;
    }

    public ArmorItemData GetArmorItemData(int _value)
    {
        for (int i = 0; i < ArmorLists.Count; i++)
        {
            if (ArmorLists[i].ItemCode == _value)
            {
                return ArmorLists[i];
            }
        }
        return null;
    }

    public PortionItemData GetPortionItemData(int _value)
    {
        for (int i = 0; i < PortionLists.Count; i++)
        {
            if (PortionLists[i].ItemCode == _value)
            {
                return PortionLists[i];
            }
        }
        return null;
    }

    public ItemData GetGoldItemData(int _value)
    {
        for (int i = 0; i < Goldlists.Count; i++)
        {
            if (Goldlists[i].ItemCode == _value)
            {
                return PortionLists[i];
            }
        }
        return null;
    }




    #region 몬스터 잡으면 아이템 랜덤으로 뿌려지게 하는 로직
    /*
     * 
     * 애초에 확률 확률이 높지 않음 골드는 백퍼확률로 떨군다고 해보자
     * 무기는 5퍼, 장구류는 10퍼확률로 떨군다고 하자
     * 그 5퍼 확률에서도 좋은 아이템이 나올 확률이 달라야한다
     * 어떻게 생성해야할까?
     * 
     * 5퍼, 10퍼, 15퍼 20퍼 50퍼
     * 
     */

    ItemType itemType;
    ClassPrivateItems classPrivate;
    Types types;
    Ratings ratings;
    EGender gender;
    public ItemData DropItem()
    {
        
        RandomItemRogic();
        CheckGender();
        CheckJob();
        PickItemRating();
   

        return FindItem();
    }

    public ItemData FindItem()
    {
        if(itemType == ItemType.WeaponItem)
        {
            for (int i = 0; i < WeaponLists.Count; i++)
            {

                if (WeaponLists[i].Type == types)
                {
                    if (WeaponLists[i].Rating == ratings)
                    {
                        return WeaponLists[i];
                    }
                    else continue;
                }
                else continue;
            }
        }
        else
        {
            for(int i =0; i<ArmorLists.Count; i++)
            {
                if (ArmorLists[i].ClassPrivateItem == classPrivate)
                {
                    if (ArmorLists[i].Type == types)
                    {
                        if (ArmorLists[i].Rating == ratings)
                        {
                            return ArmorLists[i];
                        }
                        else continue;
                    }
                    else continue;
                }
                else continue;
            }
        }

        return null;
    }

    public int RandomItemRogic()
    {
        
        //weapon, helmat, top, pants, hand, shoes
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= 15f)
        {
            itemType = ItemType.WeaponItem;
        }
        else if (randomValue <= 32f)
        {
            itemType = ItemType.ArmorItem;
            types = Types.Head;
        }
        else if (randomValue <= 49f)
        {
            itemType = ItemType.ArmorItem;
            types = Types.Top;
        }
        else if (randomValue <= 66f)
        {
            itemType = ItemType.ArmorItem;
            types = Types.Pants;
        }
        else if(randomValue<=83f)
        {
            itemType = ItemType.ArmorItem;
            types = Types.Hand;
        }
        else
        {
            itemType = ItemType.ArmorItem;
            types = Types.Shoes;
        }

        return 0;
    }

   
    public void CheckGender()
    {
        if (DataManager.GetInstance.GET_GENDERNUM(DataManager.GetInstance.SLOT_NUM) == 0)
        {
            gender = EGender.Female;
        }
        else gender = EGender.male;
    }
    public void CheckJob()
    {
        switch (DataManager.GetInstance.GET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM))
        {
            case 0:
                classPrivate = ClassPrivateItems.WARRIOR;

                if (itemType == ItemType.WeaponItem)
                {
                    float randomValue = Random.Range(0f, 100f);
                    if (randomValue <= 25f)
                    {
                        types = Types.Dagger;
                    }
                    else if (randomValue <= 50f)
                    {
                        types = Types.OneHandMace;
                    }
                    else if (randomValue <= 75f)
                    {
                        types = Types.TwoHandSword;
                    }
                    else
                    {
                        types = Types.Spear;
                    }
                }
                break;

            case 1:
                classPrivate = ClassPrivateItems.MAGE;
                if (itemType == ItemType.WeaponItem)
                {
                    float randomValue = Random.Range(0f, 100f);
                    if (randomValue <= 50f)
                    {
                        types = Types.Staff;
                    }
                    else
                    {
                        types = Types.Orb;
                    }
                }
                break;

            case 2:
                classPrivate = ClassPrivateItems.ARCHER;
                if (itemType == ItemType.WeaponItem)
                {
                    float randomValue = Random.Range(0f, 100f);
                    if (randomValue <= 50f)
                    {
                        types = Types.Bow;
                    }
                    else
                    {
                        types = Types.CrossBow;
                    }
                }
                break;
        }
    }

    public void PickItemRating()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= 5f)
        {
            ratings = Ratings.Mythic;
        }
        else if (randomValue <= 15f)
        {
            ratings = Ratings.Legendary;
        }
        else if(randomValue <=30f)
        {
            ratings = Ratings.Unique;
        }
        else if(randomValue <= 50f)
        {
            ratings = Ratings.Rare;
        }
        else
        {
            ratings = Ratings.Common;
        }
    }


    public int RandomGoldRogic()
    {

        return 0;
    }
    #endregion
}
