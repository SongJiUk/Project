using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPUI : MonoBehaviour
{
    public Slider hpBar;
    public Text hptext;
    public Slider shieldBar;
    public Text shieldtext;
    public float maxHP;
    public float maxShield;
    public float currentHp;
    public float currentShield;

    public GameObject HpLineFolder;
    float unitHp = 200f;
    public GameObject ShieldLineFolder;
    float unitShield = 200f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value = currentHp / maxHP;
        hptext.text = currentHp + "/" + maxHP;
        shieldBar.value = currentShield / maxShield;
        shieldtext.text = currentShield + "/" + maxShield;
    }

    public void GetHpBoost()
    {
        float scaleX = (1000f / unitHp) / (maxHP / unitHp);
        HpLineFolder.GetComponent<HorizontalLayoutGroup>().gameObject.SetActive(false);
        foreach (Transform child in HpLineFolder.transform)
        {
            child.gameObject.transform.localScale = new Vector3(scaleX, 1, 1);
        }
        HpLineFolder.GetComponent<HorizontalLayoutGroup>().gameObject.SetActive(true);
    }

    public void GetShieldBoost()
    {
        float scaleY = (1000f / unitShield) / (maxShield / unitShield);
        ShieldLineFolder.GetComponent<HorizontalLayoutGroup>().gameObject.SetActive(false);
        foreach (Transform child in ShieldLineFolder.transform)
        {
            child.gameObject.transform.localScale = new Vector3(scaleY, 1, 1);
        }
        ShieldLineFolder.GetComponent<HorizontalLayoutGroup>().gameObject.SetActive(true);
    }
}
