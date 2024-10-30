using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableWindow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Camera mainCamera;
    private Vector3 offset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        transform.SetAsLastSibling();

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, mainCamera, out Vector3 worldPoint);

        offset = rectTransform.position - worldPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        if (mainCamera == null) return;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, mainCamera, out Vector3 worldPoint);

        rectTransform.position = worldPoint + offset;
    }
}
