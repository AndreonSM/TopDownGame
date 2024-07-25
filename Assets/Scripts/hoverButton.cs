using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cursor;
    private RectTransform cursorTransform;

    private void Awake()
    {
        cursorTransform = cursor.GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!cursor.activeSelf)
        {
            cursor.SetActive(true);
            cursorTransform.anchoredPosition = new Vector2(0f, gameObject.GetComponent<RectTransform>().anchoredPosition.y - 210);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (cursor.activeSelf)
        {
            cursor.SetActive(false);
        }
    }
}
