using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Transform player;
    public Slider shieldBar;
    public Text shieldtext;
    public float maxShield;
    public float currentShield;

    public GameObject ShieldLineFolder;
    float unitShield = 200f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        shieldBar.value = currentShield / maxShield;
        shieldtext.text = currentShield + "/" + maxShield;
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
