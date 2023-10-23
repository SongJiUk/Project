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
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Damage();
        }
    }



    public void Damage()
    {

        GameObject DamageUI = Instantiate(_damageText, _transformto.position, _transformto.rotation);

        DamageUI.SetActive(true);



    }



}
