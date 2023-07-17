using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite unhovered;
    [SerializeField] Sprite hovered; 
    [SerializeField] Image buttonImage;
    
    public void OnEnable() {
        if (hovered) buttonImage.sprite = unhovered;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (hovered) buttonImage.sprite = hovered;
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (unhovered) buttonImage.sprite = unhovered;
    }

    public virtual void OnClick() {}
}
