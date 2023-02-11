using UnityEngine;

public class HealthBarBosses : MonoBehaviour
{
    GameManagerBehavior gameManager;
    public float maxHealthBosses;
    public float currentHealthBosses;
    private float originalScale;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        originalScale = gameObject.transform.localScale.x;
        maxHealthBosses = gameManager.HealthEnemyBosses;
        currentHealthBosses = gameManager.HealthEnemyBosses;
    }

    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealthBosses / maxHealthBosses * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
