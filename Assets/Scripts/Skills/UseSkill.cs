using System;
using UnityEngine;

public class UseSkill : MonoBehaviour
{
    public GameObject skillPrefab;
    public float time = 10f;
    private GameManagerBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();    }

    public void SkillActivate()
    {
        if (gameManager.Energy >= 0.5f)
        {
            gameManager.Energy -= 0.5f;
            GameObject skill = Instantiate(skillPrefab);
            Destroy(skill, time);
        }
    }
}