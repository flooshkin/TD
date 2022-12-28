using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool Show = false;
    public GameObject tutorial;
    public GameObject tutorialText;
    public GameObject menuPanel;

    public void onClickTutorial()
    {
        Time.timeScale = 0f;
        tutorial.SetActive(true);
        tutorialText.SetActive(true);
        Show = true;
    }
    
    public void onClickMenu()
    {
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
        Show = true;
    }
    
    public void onClickBack()
    {
        menuPanel.SetActive(false);
        Show = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            tutorial.SetActive(false);
            tutorialText.SetActive(false);
            menuPanel.SetActive(false);
            Show = false;
            Time.timeScale = 1f;
        }
    }

}