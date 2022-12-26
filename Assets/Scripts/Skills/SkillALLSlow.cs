using System.Collections;
using UnityEngine;

public class SkillALLSlow : MonoBehaviour
{
    public float timer = 1f;
    public int damage = 50;
    private GameObject enemy;
    private BaseBullet baseBullet;
    private MoveEnemy moveEnemy;
    private GameObject enemySprite;
    
    public Color startColor;
    public Color slowColor;

    private GameManagerBehavior gameManager;

    void Start()
    {
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }

    }
    
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            StartCoroutine(ToDamage(enemy));
            enemySprite = GameObject.Find("EnemyBody");
            enemySprite.transform.GetComponentInChildren<SpriteRenderer>().material.color= slowColor;
            Debug.Log(enemySprite.name);
        }

        if (enemy.gameObject.tag == "Slow")
        {
            Color one= enemy.gameObject.GetComponent <SpriteRenderer>().color;
 
            gameObject.GetComponent <SpriteRenderer>().color=one;
        }
    }

    void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            StopAllCoroutines();
            transform.GetComponent<Renderer>().material.color= startColor;
        }
    }

    private IEnumerator ToDamage(Collider2D enemy)
    {
        Transform healthBarTransform = enemy.transform.Find("HealthBar");
        HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
        damage = Mathf.Max(damage, 0);
        healthBar.currentHealth -= damage;
        StartSlow(10f,1f);
        if (healthBar.currentHealth <= 0)
        {
            Destroy(enemy.gameObject);
            AudioSource audioSource = enemy.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

            gameManager.Gold += baseBullet.gold;
            ScoreManager.score += baseBullet.score;
        }
        yield return new WaitForSeconds(1.0f);
    }
    
    public void StartSlow(float duration, float slowValue)
    {
        StopCoroutine("GetSlow");
        moveEnemy.speed = moveEnemy.startSpeed;
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        moveEnemy.speed -= slowValue;
        yield return new WaitForSeconds(duration);
        moveEnemy.speed = moveEnemy.startSpeed;
    }
}