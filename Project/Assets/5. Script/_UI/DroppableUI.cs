using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=uTeZz4O12yU

public class DroppableUI : MonoBehaviour, IPointerEnterHandler , IDropHandler , IPointerExitHandler
{
    private Image image;
    private RectTransform rect;
    private GameObject child;
    Transform CurrentItem = null;

    private void Awake()
    {
        if (transform.childCount <= 1)
        {
            CurrentItem = transform.GetChild(0);
        }

       // child = gameObject.GetComponentInChildren
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    //마우스 포인터가 현재 아이템 슬롯 영역 내부로 들어갈 때 1회 호출
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    //마우스 포인터가 현재 아이템 슬롯 영역을 빠져나갈 때 1회 호출
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(0.1568628f, 0.1411765f, 0.1137255f);
    }

    
    //현재 아이템 슬롯 영역 내부에서 드롭을 했을 때 1회 호출
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag !=null&& eventData.pointerDrag.tag != "InventorySlot")
        {
            if (CurrentItem == null)
            {
                CurrentItem = eventData.pointerDrag.transform;
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            }
            else
            {
                DraggableUI d =  eventData.pointerDrag.transform.GetComponent<DraggableUI>();
                CurrentItem.SetParent(d.previousParentreturn());
                CurrentItem.localPosition = Vector3.zero;
                CurrentItem = null;



                CurrentItem = eventData.pointerDrag.transform;
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            }

            //transform

            //child = transform.GetChild(0);
        }
    }
}
