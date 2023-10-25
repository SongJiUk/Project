using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSlotUI : MonoBehaviour
{
    [Tooltip("스킬 아이콘 이미지")]
    [SerializeField] private Image _iconImage;
    [Tooltip("스킬 쿨다운 이미지")]
    [SerializeField] private Image _coolDown;

    float _starttime = 0;
    float _time = 0;
    float value = 0;
    // Update is called once per frame

    private void Awake()
    {
        SetCoolTime(5);
    }

    void Update()
    {
        if(_time>0)
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                SetCoolDown();
            }
            if (_time > 0 && _starttime > 0)
            {
                value = _time / _starttime;
            }
            else
            {
                value = 0;
            }
            SetIconTime(value);
        }
    }

    /// <summary> 아이콘 이미지 설정 </summary>
    public void SetIconImage(Sprite image)
    {
        _iconImage.sprite = image;
    }
    public void SetCoolTime(float time)
    {
        _starttime = time;
        _time = _starttime;
    }
    public void SetIconTime(float value)
    {
        _coolDown.fillAmount = value;
    }
    public void SetCoolDown()
    {
        _starttime = 0;
        _time = _starttime;
    }
}
