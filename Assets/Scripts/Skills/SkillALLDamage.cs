using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SkillALLDamage : MonoBehaviour
{
    [SerializeField]
    private float timer = 1f;
    [SerializeField]
    private int damage = 50;
    private GameObject enemy;
    private BaseBullet baseBullet;
    [SerializeField]
    private float CoolDawn = 0f;
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
}
