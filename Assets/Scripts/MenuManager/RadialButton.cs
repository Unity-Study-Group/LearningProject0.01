using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image circle;
    public Image Icon;
    public string title;
    public RadialMenu myMenu;
    public Text label;
    public Ability ability;
    Color defaultColor;

    void Start()
        {
        label.text = title;
        label.enabled = false;
        }

    public void OnPointerEnter(PointerEventData eventData)
        {
        myMenu.selected = ability;
        defaultColor = circle.color;
        RectTransform rectT = GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2(30f, 30f);
        label.rectTransform.localPosition = new Vector2(0f, 40f);
        //label.enabled = true;
        }

    public void OnPointerExit(PointerEventData eventData)
        {
        myMenu.selected = null;
        circle.color = defaultColor;
        RectTransform rectT = GetComponent<RectTransform>();
        rectT.sizeDelta = new Vector2(20f, 20f);
        label.enabled = false;
        }
}
