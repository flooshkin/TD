using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    bool Show = false;
    public GameObject tutorial;
    public GameObject tutorialText;
    public GameObject menuPanel;
    public GameObject removeButton;

    public static bool RemoveButtonSelected = false;

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

    public void onClickExit()
    {
        Application.Quit();
    }

    public void onRemoveTowerClick()
    {
        if (RemoveButtonSelected)
        {
            DeactivateRemoveState();
        }
        else
        {
            ActivateRemoveState();
        }
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
            // menuPanel.SetActive(false);
            Show = false;
            Time.timeScale = 1f;
        }
    }

    private void ActivateRemoveState()
    {
        RemoveButtonSelected = true;
        removeButton.GetComponentInChildren<Text>().text = "Select tower";
        removeButton.GetComponentInChildren<SpriteRenderer>().color = Color.gray;
    }
    
    public void DeactivateRemoveState()
    {
        RemoveButtonSelected = false;
        removeButton.GetComponentInChildren<Text>().text = "Sell tower";
        removeButton.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}