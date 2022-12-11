using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowRange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject rangeImage;


    void IPointerEnterHandler.OnPointerEnter(PointerEventData e)
    {
        rangeImage.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData e)
    {
        rangeImage.SetActive(false);
    }
}