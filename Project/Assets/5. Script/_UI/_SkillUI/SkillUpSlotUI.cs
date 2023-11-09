using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.ShaderGraph;
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
}
