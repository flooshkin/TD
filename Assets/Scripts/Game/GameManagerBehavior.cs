using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{

    public Text goldLabel;
    private int gold;
    public GameObject BountyPref;
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public bool gameOver = false;
    public Text healthLabel;
    public GameObject[] healthIndicator;
    public static GameManagerBehavior Instance;

    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
            waveLabel.text = "WAVE: " + (wave + 1);
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = " " + gold;
        }
    }

    public void ShowBounty(int bounty)
    {
        Gold += bounty;
        GameObject bountyObj = Instantiate(BountyPref);
        bountyObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        bountyObj.GetComponent<BountyScr>().SetParams(bounty);
    }

    private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            health = value;
            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
                SceneManager.LoadScene(2);
            }
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }

    void Start()
    {
        Gold = 1000;
        Wave = 0;
        Health = 5;
    }

    void Update()
    {

    }
}
