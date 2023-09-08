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

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;

        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData evetData)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
