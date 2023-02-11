using System.Collections;
using UnityEngine;

public class SkillALLSlow : MonoBehaviour
{
    [SerializeField]
    private float timer = 1f;
    [SerializeField]
    private float damage = 0;
    private GameObject enemy;
    private BaseBullet baseBullet;
    private MoveEnemy moveEnemy;
    [SerializeField]
    private float CoolDawn = 1f;
    [SerializeField]
    private float Energy = 1f;
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
        if (enemy.gameObject.tag == "Blizzard")
        {
            GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
            sprite.GetComponentInChildren<SpriteRenderer>().color = new Color(0.35f, 0.56f, 1f);
            StartCoroutine(TimeActive(2f));
        }
    }

    IEnumerator TimeActive(float duration)
    {
        yield return new WaitForSeconds(duration);
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }

    void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
        {
            StartCoroutine(ToDamage(enemy));
        }
    }

    void OnTriggerExit2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Enemy")
            StopAllCoroutines();
    }

    private IEnumerator ToDamage(Collider2D enemy)
    {
        Transform healthBarTransform = enemy.transform.Find("HealthBar");
        HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
        damage = Mathf.Max(damage, 0);
        healthBar.currentHealth -= damage;
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
        moveEnemy.startSpeed = moveEnemy.speed;
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        moveEnemy.startSpeed -= slowValue;
        yield return new WaitForSeconds(duration);
        moveEnemy.startSpeed = moveEnemy.speed;
    }
}