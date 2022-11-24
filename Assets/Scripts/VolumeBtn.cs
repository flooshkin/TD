using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBtn : MonoBehaviour
{
    public GameObject tutorial;

    public void OnClick()
    {
        Debug.Log("клик");
        tutorial.SetActive(!tutorial.activeSelf);

    }
}
