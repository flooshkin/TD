using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    AOE_TOWER,
    SLOW_TOWER,
    CRIT_TOWER,
    EPICK_TOWER
}

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public int bounty;

    private float distance;
    private float startTime;

    private GameManagerBehavior gameManager;

    void Start()
    {
        startTime = Time.time;
        distance = Vector2.Distance(startPosition, targetPosition);
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }
    
    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                damage = Mathf.Max(damage, 0);
                healthBar.currentHealth -= damage;
                if (healthBar.currentHealth <= 0)
                {
                    Destroy(target);
                    AudioSource audioSource = target.GetComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

                    gameManager.Gold += 10;
                }
            }
            Destroy(gameObject);
        }
    }
}
