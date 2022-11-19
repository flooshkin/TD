using UnityEngine;
using System.Collections;

public class TutorialScr : MonoBehaviour
{

    public void DisplayTutorial()
    {
        gameObject.GetComponent<Animator>().SetTrigger("displayTutorial");
    }

}
