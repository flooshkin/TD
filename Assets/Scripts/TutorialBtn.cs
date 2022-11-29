using UnityEngine;

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
}

