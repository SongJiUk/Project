//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PickUpUIPrefab : MonoBehaviour
{
    [Tooltip("?????? ??????")]
    [SerializeField] private UnityEngine.UI.Image _pickUpNowImage;

    [Tooltip("?????? ?????? ??????")]
    [SerializeField] private UnityEngine.UI.Image _iconImage;

    [Tooltip("?????? ???? ??????")]
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

    public void SetObjPickUpOn()
    {
        _pickUpNowImage.color = new Color(1, 1, 1, 1);
    }

    public void SetObjPickUpOff()
    {
        _pickUpNowImage.color = new Color(1, 1, 1, 0);
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

    public GameObject ReturnObj()
    {
        return this.gameObject;
    }
}
