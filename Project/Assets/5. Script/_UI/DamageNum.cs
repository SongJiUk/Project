using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DamageNum : MonoBehaviour
{
    [Tooltip("데미지 텍스트 프리팹")]
    [SerializeField] private GameObject _damageText;

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

    private void Update()
    {

    }

    public void Damage(float damage, int color, Transform _transformHit)
    {
        _transformto = _transformHit;
        GameObject DamageUI = Instantiate(_damageText, _canvas);
        Vector3 positionUI = (_transformto.position + (Random.insideUnitSphere * 1f));
        DamageUI.transform.position = Camera.main.WorldToScreenPoint(positionUI);
        DamageUI.SetActive(true);
        DamageNumPrefab DamageUIValue = DamageUI.GetComponent<DamageNumPrefab>();
        DamageUIValue.SetPosition(positionUI);
        DamageUIValue.SetDamage(damage);
        DamageUIValue.SetColor(color);
        

    }



}
