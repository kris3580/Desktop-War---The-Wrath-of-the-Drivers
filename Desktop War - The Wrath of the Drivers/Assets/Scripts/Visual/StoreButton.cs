using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{

    private GameObject highlightSquare;
    private RectTransform rect;

    private void Start()
    {
        highlightSquare = transform.parent.Find("HighlightSquare").gameObject;
        rect = highlightSquare.GetComponent<RectTransform>();
        highlightSquare.SetActive(false);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0.59f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        highlightSquare.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        highlightSquare.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Pause.isPaused) return;

        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0.01f);
    }
}
