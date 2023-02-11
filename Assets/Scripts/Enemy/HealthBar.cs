using UnityEngine;

public class HealthBar : MonoBehaviour
{
    GameManagerBehavior gameManager;
    public float maxHealth;
    public float currentHealth;
    private float originalScale;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        originalScale = gameObject.transform.localScale.x;
        maxHealth = gameManager.HealthEnemy;
        currentHealth = gameManager.HealthEnemy;
    }

    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
