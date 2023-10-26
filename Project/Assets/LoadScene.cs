using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] Image BG;
    [SerializeField] Sprite[] BG_Img;

    [SerializeField] Text GameTip_txt;
    //던전에서 게임종료시 마을로 이동됩니다.
    [SerializeField] Text LoadingNum_txt;

    [SerializeField] Image LoadingGauge_img;
    void Start()
    {
        int num = Random.Range(0, BG_Img.Length);
        BG.sprite = BG_Img[num];
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(LoadManager.GetInstance.LoadNum);
        LoadingNum_txt.text = $"{((int)(LoadManager.GetInstance.LoadNum * 100f)).ToString()}%";
        LoadingGauge_img.fillAmount = LoadManager.GetInstance.LoadNum / 1f;
    }
}
