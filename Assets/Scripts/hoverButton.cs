using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject cursor;


    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, gameObject.GetComponent<RectTransform>().anchoredPosition.y-210);
        cursor.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.SetActive(false);
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
