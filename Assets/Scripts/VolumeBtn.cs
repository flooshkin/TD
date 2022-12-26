using UnityEngine;

public class VolumeBtn : MonoBehaviour
{
    public GameObject tutorial;

    public void OnClick()
    {
        tutorial.SetActive(!tutorial.activeSelf);
    }
}
