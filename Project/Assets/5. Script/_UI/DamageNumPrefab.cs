using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DamageNumPrefab : MonoBehaviour
{
    [Tooltip("데미지 텍스트")]
    [SerializeField] private Text _amountText;

    [SerializeField] float timeStart = 3;

    [SerializeField] float textup = 2;

    [SerializeField] float textdown = 1;

    [SerializeField] float textsizeMax = 0.1f; 
    [SerializeField] float textsizeMin = 0.01f;

    float time = 10;

    float textsize = 0.1f;

    float t = 0;

    Vector3 _positioning;

    // Start is called before the first frame update
    void Awake()
    {
        time = timeStart;
    }
    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(_positioning);
        if (time >= 0)
            time -= Time.deltaTime;

        if (time > textup)
        {
            t = timeStart - time;
        }
        else if (time <= textup && time > textdown)
        {
            t = 1;
        }
        else if (time <= textdown && time > 0)
        {
            t = time;
        }
        else
        {
            DestroyNow();
        }

        textsize = textsizeMin * (1 - t) + textsizeMax * t;

        transform.localScale = new Vector3(textsize, textsize, textsize);

    }

    public void SetPosition(Vector3 positioning)
    {
        _positioning = positioning;
    }

    public void SetDamage(float damage)
    {
        _amountText.text = damage.ToString();
    }

    public void SetColor(int num)
    {
        if (num == 1)
        {
            _amountText.color = new Color(1, 0, 0, 1);
        }
        else if (num == 2)
        {
            _amountText.color = new Color(0, 1, 0, 1);
        }
        else if (num == 3)
        {
            _amountText.color = new Color(0, 0, 1, 1);
        }
        else
        {
            _amountText.color = new Color(1, 1, 1, 1);
        }
    }

    private void DestroyNow()
    {
        Destroy(this.gameObject);
    }
}
