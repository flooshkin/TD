using UnityEngine;

public class SelectColor : MonoBehaviour
{
    private Color startcolor;
    void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0.53f, 1f, 0.67f);
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1f,2f,3f);
    }
}
