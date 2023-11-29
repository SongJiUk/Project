using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    float smoothSpeed = 3f;
    Quaternion targetRotation;

    [Header("???????? ???? ?????? ???? ??")]
    [SerializeField] GameObject StartJobBtn;
    [SerializeField] GameObject[] Characters;


    [Header("???? ???????? ???? ???? ????")]
    [SerializeField] Transform StartAnimPos;
    [SerializeField] Transform[] Job_Pos;
    [SerializeField] Transform[] Job_SkillView_Pos;
    [SerializeField] Transform Origin_pos;


    [Header("?? ?????? ???????? ???????? ???? ????")]
    [SerializeField] GameObject Job_Skill_Popup;
    [SerializeField] GameObject[] Job_Explanation_Top_txt;
    [SerializeField] GameObject[] Job_Explanation_popup;
    [SerializeField] GameObject[] Job_KindBtn;
    [SerializeField] GameObject Back_btn;


    [SerializeField] string[] Character_name;



    Coroutine myCoroutine;
    bool isJoom = false;
    public bool isShowSkill = false;
    int num = 0;

    private void Start()
    {
        StartCoroutine(StartScene());
    }

    float time = 0;
    public IEnumerator StartScene()
    {
        while(true)
        {
            yield return null;
            transform.rotation = Quaternion.Slerp(transform.rotation, StartAnimPos.rotation, smoothSpeed * Time.deltaTime);
            time += Time.deltaTime;
            if (time > 2f)
            {
                StartJobBtn.SetActive(true);
                time = 0f;
                break;
            }
        }
    }


    public void ShowCharacter(int _num)
    {
        time = 0f;
        isJoom = true;
        //targetRotation = Quaternion.Euler(30.0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (myCoroutine != null) StopCoroutine(myCoroutine);
        myCoroutine = StartCoroutine(LateUpdates(_num));
        StartJobBtn.SetActive(false);
        Back_btn.SetActive(true);
        num = _num;
        
    }

    public void BackToOriginPos()
    {
        time = 0f;
        isJoom = false;
        //targetRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
        if (myCoroutine != null) StopCoroutine(myCoroutine);
        myCoroutine = StartCoroutine(LateUpdates(num));
        Job_Skill_Popup.SetActive(false);
        Back_btn.SetActive(false);
        
    }

    public void ShowSkill()
    {
        isShowSkill = true;
        Job_Skill_Popup.SetActive(false);
    }
    public void SelectCharacter(int _num)
    {
        UnitCode _code = (UnitCode)_num;
        
        DataManager.GetInstance.SET_UnitCodes(DataManager.GetInstance.SLOT_NUM, _code);
        DataManager.GetInstance.SET_PLAYER_JOB(DataManager.GetInstance.SLOT_NUM, _num);
        DataManager.GetInstance.SaveData(DataManager.GetInstance.SLOT_NUM);

        var operation = SceneManager.LoadSceneAsync("3_Customizing");
        operation.allowSceneActivation = true;
    }


    IEnumerator LateUpdates(int _num)
    {
        while (true)
        {
            if(isShowSkill)
            {
                transform.position = Vector3.Lerp(transform.position, Job_SkillView_Pos[_num].position, smoothSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Job_SkillView_Pos[_num].rotation, smoothSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                if (isJoom)
                {
                    transform.position = Vector3.Lerp(transform.position, Job_Pos[_num].position, smoothSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, Job_Pos[_num].rotation, smoothSpeed * Time.deltaTime);
                    time += Time.deltaTime;
                    if (time > 2f)
                    {
                        Job_Explanation_Top_txt[_num].SetActive(true);
                        Job_Explanation_popup[_num].SetActive(true);
                        Job_Skill_Popup.SetActive(true);
                        Job_KindBtn[_num].SetActive(true);
                    }
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, Origin_pos.position, smoothSpeed * Time.deltaTime);
                    transform.rotation = Quaternion.Slerp(transform.rotation, StartAnimPos.rotation, smoothSpeed * Time.deltaTime);
                   
                    time += Time.deltaTime;
                    if (time > 2f)
                    {
                        Job_Explanation_Top_txt[_num].SetActive(false);
                        Job_Explanation_popup[_num].SetActive(false);
                        StartJobBtn.SetActive(true);
                        Job_KindBtn[num].SetActive(false);
                    }
                    yield return new WaitForEndOfFrame();
                }
            }
            
           
        }
    }


}

