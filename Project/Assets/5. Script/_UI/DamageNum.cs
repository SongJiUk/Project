//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DamageNum : MonoBehaviour
{
    [Tooltip("?????? ?????? ??????")]
    [SerializeField] private GameObject _damageText;
    [SerializeField] private GameObject _damageText_critical;
    [SerializeField] private GameObject _Avoidance;
    [SerializeField] private GameObject _LevelUP;

    [SerializeField] private Transform _transformto;

    [SerializeField] private Transform _canvas;

    public static DamageNum instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void LevelUP()
    {

        _LevelUP.SetActive(true);
    }


    public void Damage(float damage, int color, Transform _transformHit, bool _isCritical, bool _isAvoidance = false, bool _isPlayerHit = false)
    {
        GameObject DamageUI;
        if(_isAvoidance)
        {
            DamageUI = Instantiate(_Avoidance, _canvas);
            damage = 0;
        }
        else
        {
            if (_isCritical)
            {
                DamageUI = Instantiate(_damageText_critical, _canvas);
            }
            else
            {
                DamageUI = Instantiate(_damageText, _canvas);
            }
        }
        
        _transformto = _transformHit;

        //Vector3 positionUI = (_transformto.position + (Random.insideUnitSphere));
        Vector3 positionUI = _transformto.position + Vector3.up;
        DamageUI.transform.position = Camera.main.WorldToScreenPoint(positionUI);
        DamageUI.SetActive(true);
        DamageNumPrefab DamageUIValue = DamageUI.GetComponent<DamageNumPrefab>();
        DamageUIValue.SetPosition(positionUI);
        DamageUIValue.SetDamage(damage);

        if(_isPlayerHit) DamageUIValue.SetColor(color);

    }



}
