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

    bool inventory = false;
    bool equip = false;
    bool useitem = false;
    int num = 0;

    bool fullslot = false;

    private void Awake()
    {
        if (transform.childCount >= 1)
        {
            CurrentItem = transform.GetChild(0);
        }

       // child = gameObject.GetComponentInChildren
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

    public void setting(int op, int numbering)
    {
        if(op==0)
        {
            inventory = true;
            equip = false;
            useitem = false;
        }
        else if(op==1)
        {
            equip = true;
            inventory = false;
            useitem = false;
        }
        else if(op==2)
        {
            useitem = true;
            inventory = false;
            equip = false;
        }
        else
        {

        }
        num = numbering;
        Debug.Log(numbering);
    }

    //���콺 �����Ͱ� ���� ������ ���� ���� ���η� �� �� 1ȸ ȣ��
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.white;
    }

    //���콺 �����Ͱ� ���� ������ ���� ������ �������� �� 1ȸ ȣ��
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(0.1568628f, 0.1411765f, 0.1137255f);
    }

    
    //���� ������ ���� ���� ���ο��� ����� ���� �� 1ȸ ȣ��
    public void OnDrop(PointerEventData eventData)
    {
        if(useitem)
        {
            if (eventData.pointerDrag != null && eventData.pointerDrag.tag != "InventorySlot")
            {
                if (CurrentItem == null)
                {
                    CurrentItem = eventData.pointerDrag.transform;
                    eventData.pointerDrag.transform.SetParent(transform);
                    eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                }
                else
                {
                    DraggableUI d = eventData.pointerDrag.transform.GetComponent<DraggableUI>();
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
        else if(equip)
        {
            if (eventData.pointerDrag != null && eventData.pointerDrag.tag != "InventorySlot")
            {
                if (CurrentItem == null)
                {
                    CurrentItem = eventData.pointerDrag.transform;
                    eventData.pointerDrag.transform.SetParent(transform);
                    eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                }
                else
                {
                    DraggableUI d = eventData.pointerDrag.transform.GetComponent<DraggableUI>();
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
        else if(inventory)
        {
            if (eventData.pointerDrag != null && eventData.pointerDrag.tag != "InventorySlot")
            {
                if (CurrentItem == null)
                {
                    CurrentItem = eventData.pointerDrag.transform;
                    eventData.pointerDrag.transform.SetParent(transform);
                    eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
                }
                else
                {
                    DraggableUI d = eventData.pointerDrag.transform.GetComponent<DraggableUI>();
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
}
