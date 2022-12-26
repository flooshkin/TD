using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool Show = false;
    public GameObject tutorial;
    public GameObject tutorialText;

    public void onClick()
    {
        Time.timeScale = 0f;
        tutorial.SetActive(true);
        tutorialText.SetActive(true);
        Show = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            tutorial.SetActive(false);
            tutorialText.SetActive(false);
            Show = false;
            Time.timeScale = 1f;
        }
    }

}