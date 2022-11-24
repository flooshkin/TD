using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBtn : MonoBehaviour
{
    bool Show = false;
    public GameObject tutorial;

    public void onClick()
    {

    }

    public void onDown()
    {
        tutorial.SetActive(true);
        Show = true;
    }

    public void onUp()
    {
        tutorial.SetActive(false);
        Show = false;
    }

    void Update()
    {
        if (Show);
    }
}

