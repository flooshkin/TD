using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{

    public Text goldLabel;
    private int gold;
    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public Text waveBossesLabel;
    public GameObject[] nextWaveBossesLabels;
    public bool gameOver = false;
    public GameObject[] healthIndicator;
    public static GameManagerBehavior Instance;
    public float CoolDawn = 0f;
    public float Energy = 1f;
    public Image UIEnergy;
    private TowerPlaceScr selectedTower;
    [SerializeField] 
    private int loadSceneID;

    public int HealthEnemy = 50;
    public int HealthEnemyBosses = 200;
    [SerializeField] private int LifeIncrease = 10;
    [SerializeField] private int LifeIncreaseBosses = 100;
    [SerializeField] private Button blizzard;
    [SerializeField] private Button meteorRain;
    [SerializeField] private Button fullPower;
    

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
            HealthEnemy += LifeIncrease;
        }
    }

    private int waveBosses;
    public int WaveBosses
    {
        get
        {
            return waveBosses;
        }
        set
        {
            waveBosses = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveBossesLabels.Length; i++)
                {
                    nextWaveBossesLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
            waveLabel.text = "Wave " + (wave + 1);
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

    private int health = 5;
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
                SceneManager.LoadScene(loadSceneID);
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
        Gold = 300;
        Wave = 0;
        Health = 5;
        
        Button meteor = meteorRain.GetComponent<Button>();
        meteor.onClick.AddListener(TaskOnClick);
        
        Button bliz = blizzard.GetComponent<Button>();
        bliz.onClick.AddListener(TaskOnClick);
        
        Button power = fullPower.GetComponent<Button>();
        power.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        CoolDawn = 15f;
        Energy -= 0.5f;
    }

    void Update()
    {
        UIEnergy.fillAmount = Energy;
        CoolDawn -= Time.deltaTime;
        
        if (Energy < 1f)
        {
            Energy += Time.deltaTime / 100f;
        }
    }

    public void SelectTower(TowerPlaceScr tower)
    {
        if (selectedTower != null)
        {
            selectedTower.Select();
        }

        selectedTower = tower;

        selectedTower.Select();
    }

    public void DeselectTower()
    {
        if (selectedTower != null)
        {
            selectedTower.Select();
        }

        selectedTower = null;
    }    
}
