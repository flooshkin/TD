using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject panel;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData e)
    {
        panel.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData e)
    {
        panel.SetActive(false);
    }
}