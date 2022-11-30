﻿using UnityEngine;
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
    public GameObject skill1;
    public float CoolDawn = 0f;
    public float Energy = 1f;
    public Image UIEnergy;

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
        UIEnergy.fillAmount = Energy;
        CoolDawn -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1) & CoolDawn<0 & Energy>0.5f)
        { 
            Instantiate(skill1, transform.position, transform.rotation);
            CoolDawn = 15f;
            Energy = Energy - 0.5f;
            
        }
        if (Energy < 1f)
        {
            Energy += Time.deltaTime / 100f;
        }
    }
}
