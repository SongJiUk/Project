using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*
    [상속 구조]

    ItemData(abstract)
        - CountableItemData(abstract)
            - PortionItemData
        - EquipmentItemData(abstract)
            - WeaponItemData
            - ArmorItemData

*/

public enum Ratings
{
    Common,
    Rare,
    Unique,
    Legendary,
    Mythic
}

public enum ItemType
{
    PortionItem,
    WeaponItem,
    ArmorItem
}

public abstract class ItemData : ScriptableObject
{
    public int ItemCode => _itemcode;
    public string Name => _name;
    public string Tooltip => _tooltip;
    public Sprite IconSprite => _iconSprite;
    public Ratings Rating => _rating;
    public ItemType ItemType => _itemtype;

    [SerializeField] private Ratings _rating;
    [SerializeField] private int _itemcode;
    [SerializeField] private string _name;    // 아이템 이름
    [Multiline]
    [SerializeField] private string _tooltip; // 아이템 설명
    [SerializeField] private Sprite _iconSprite; // 아이템 아이콘
    [SerializeField] private GameObject _dropItemPrefab; // 바닥에 떨어질 때 생성할 프리팹
    [SerializeField] private GameObject _SettingItem; // 착용 아이템

    [SerializeField] private ItemType _itemtype;

    /// <summary> 타입에 맞는 새로운 아이템 생성 </summary>
    public abstract Item CreateItem();
}
