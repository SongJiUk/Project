using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PickUpUIPrefab : MonoBehaviour
{
    [Tooltip("아이템 아이콘 이미지")]
    [SerializeField] private UnityEngine.UI.Image _iconImage;

    [Tooltip("아이템 이름 텍스트")]
    [SerializeField] private Text _amountText;

    private GameObject _aroundItemObj;

    public void SetIconImage(Sprite icon)
    {
        _iconImage.sprite = icon;
    }

    public void SetText(string text)
    {
        _amountText.text = text;
    }

    public void SetObj(GameObject obj)
    {
        _aroundItemObj = obj;
    }

    public GameObject FindObj(GameObject obj)
    {
        if(obj== _aroundItemObj)
        {
            return this.gameObject;
        }
        else
        {
            return null;
        }
    }
}
