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

    //���� ������Ʈ�� �巡���ϱ� ������ �� 1ȸ ȣ��
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;

        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    //���� ������Ʈ�� �巡�� ���� �� �� ������ ȣ��
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    //���� ������Ʈ�� �巡�׸� ������ �� 1ȸ ȣ��
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
