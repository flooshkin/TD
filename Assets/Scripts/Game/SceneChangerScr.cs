using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScr : MonoBehaviour
{
    public void ChangeScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}

