using UnityEngine;
using UnityEngine.EventSystems;

//https://www.youtube.com/watch?v=uTeZz4O12yU

public class DraggableUI : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private Transform previousParent;
    private RectTransform rect;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public Transform previousParentreturn()
    {
        return previousParent;
    }

    //현재 오브젝트를 드래그하기 시작할 때 1회 호출
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;

        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    //현재 오브젝트를 드래그 중일 때 매 프레임 호출
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    //현재 오브젝트의 드래그를 종료할 때 1회 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent==canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }
        

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
