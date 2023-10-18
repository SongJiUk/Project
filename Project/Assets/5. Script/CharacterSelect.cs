using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    float smoothSpeed = 5.0f;
    Quaternion targetRotation;
    [SerializeField] Transform[] Job_Pos;
    [SerializeField] Transform Origin_pos;
    [SerializeField] GameObject[] Job_KingBtn;
    [SerializeField] GameObject Job_btn;
    [SerializeField] GameObject Back_btn;



    Coroutine myCoroutine;
    bool isJoom = false;
    int num = 0;
    

    public void ShowCharacter(int _num)
    {
        isJoom = true;
        targetRotation = Quaternion.Euler(30.0f, transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z);
        if (myCoroutine != null) StopCoroutine(myCoroutine);
        myCoroutine = StartCoroutine(LateUpdates(_num));
        Job_btn.SetActive(false);
        Back_btn.SetActive(true);
        num = _num;
        Job_KingBtn[_num].SetActive(true);
    }

    public void BackToOriginPos()
    {
        isJoom = false;
        targetRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y,
            transform.rotation.eulerAngles.z);
        if (myCoroutine != null) StopCoroutine(myCoroutine);
        myCoroutine = StartCoroutine(LateUpdates(num));
        Job_btn.SetActive(true);
        Back_btn.SetActive(false);
        Job_KingBtn[num].SetActive(false);
    }

    public void SelectCharacter(int _num)
    {
        UnitCode _code = (UnitCode)_num;
        
        DataManager.GetInstance.UnitCodes(DataManager.GetInstance.SLOT_NUM, _code);


        var operation = SceneManager.LoadSceneAsync("3_Customizing");
        operation.allowSceneActivation = true;
    }


    IEnumerator LateUpdates(int _num)
    {
        while (true)
        {
            if(isJoom)
            {
                transform.position = Vector3.Lerp(transform.position, Job_Pos[_num].position, smoothSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, Origin_pos.position, smoothSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
           
        }
    }


}

