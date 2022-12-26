using UnityEngine;

public class ShowRange : MonoBehaviour
{

    public GameObject rangeImage;


    void OnMouseEnter()
    {
        rangeImage.SetActive(true);
        Debug.Log("навел");
    }

    void OnMouseExit()
    {
        rangeImage.SetActive(false);
        Debug.Log("отвел");
    }
}