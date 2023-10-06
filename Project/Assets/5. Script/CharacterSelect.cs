using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    float smoothSpeed = 5.0f;

    [SerializeField] Transform[] a;

    Vector3 OriginalPos;
    Coroutine myCoroutine;
    private void Awake()
    {
        OriginalPos = transform.position;
    }

    public void ShowCharacter(int _num)
    {
        if (myCoroutine != null) StopCoroutine(myCoroutine);
        myCoroutine = StartCoroutine(LateUpdates(_num));
        Debug.Log("Click:");
    }



    IEnumerator LateUpdates(int _num)
    {
        while (true)
        {
            Vector3 Position = Vector3.Lerp(transform.position, a[_num].position, smoothSpeed * Time.deltaTime);
            transform.position = Position;
            yield return new WaitForEndOfFrame();
        }
    }
}

