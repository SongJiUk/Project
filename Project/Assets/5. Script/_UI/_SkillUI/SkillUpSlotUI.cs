using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using UnityEditor.ShaderGraph;
using System.Xml.Linq;


public class SkillUpSlotUI : MonoBehaviour
{
    /***********************************************************************
    *                               Option Fields
    ***********************************************************************/
    #region .
    [Tooltip("스킬 아이콘 이미지")]
    [SerializeField] private Image _iconImage;

    [Tooltip("스킬 아이콘 이미지")]
    [SerializeField] private Sprite _imageSprite;

    [Tooltip("스킬 레벨 텍스트")]
    [SerializeField] private Text _levelText;

    [Tooltip("슬롯이 포커스될 때 나타나는 하이라이트 이미지")]
    [SerializeField] private Image _highlightImage;

    [Tooltip("슬롯이 포커스될 때 나타나는 하이라이트 이미지")]
    [SerializeField] private int _upValue;

    [Tooltip("슬롯이 포커스될 때 나타나는 하이라이트 이미지")]
    [SerializeField] private int nowVlue;

    [Tooltip("스킬 이름")]
    [SerializeField] private string _skillName;

    [Tooltip("스킬 설명")]
    [SerializeField] private string _skillInformation;

    [Tooltip("지금 크기")]
    [SerializeField] private string _skillNow;

    [Tooltip("다음 크기")]
    [SerializeField] private string _skillNext;

    [Tooltip("래벨당 벨류 크기")]
    [SerializeField] private int _skillValue; 
    

    private InventoryUI _inventoryUI;
    private int _level = 0;
    #endregion

    /***********************************************************************
    *                               Unity Events
    ***********************************************************************/
    #region .
    private void Awake()
    {
        Highlight(false);
        SetIconImage(_imageSprite);
        SetLevelNum();
    }

    #endregion
    /***********************************************************************
    *                               Public Methods
    ***********************************************************************/
    #region .

    /// <summary> 하이라이트 이미지를 아이콘 이미지의  투명도 설정 </summary>
    public void Highlight(bool value)
    {
        if (value)
        {
            _highlightImage.color = new Color(0.8f, 1f, 0.4f, 0.5f);
        }
        else
        {
            _highlightImage.color = new Color(0.8f, 1f, 0.4f, 0f);
        }
    }

    /// <summary> 아이콘 이미지 설정 </summary>
    public void SetIconImage(Sprite image)
    {
        _iconImage.sprite = image;
    }
    public void SetLevelUp()
    {
        if (_level < 5)
        {
            _level++;
            SetLevelNum();
        }
        else
        {
            _level = 5;
            SetLevelNum();
        }
    }
    public void SetLevel(int level)
    {
        _level = level;
        SetLevelNum();
    }

    /// <summary> 아이콘 이미지 설정 </summary>
    public void SetLevelNum()
    {
        _levelText.text = $"Level : {_level}";
    }
    #endregion

    public Sprite ReturnImage()
    {
        return _imageSprite;
    }

    public string ReturnName()
    {
        return _skillName;
    }
    public string ReturnText1()
    {
        return _skillInformation;
    }
    public string ReturnText2()
    {
        string ReplaceResult = _skillNow.Replace("Value", SkillNowValue());
        return ReplaceResult;
    }
    public string ReturnText3()
    {
        string ReplaceResult = _skillNow.Replace("Value", SkillNextValue());
        return ReplaceResult;
    }
    public int ReturnSkillLevel()
    {
        return _level;
    }
    public int ReturnSkillValue()
    {
        int value = _level * _skillValue;
        return value;
    }
    private string SkillNowValue()
    {
        int num = ReturnSkillValue();
        string value = num.ToString();
        return value;
    }
    private string SkillNextValue()
    {
        int num = ReturnSkillValue() + _skillValue;
        string value = num.ToString();
        return value;
    }
}
