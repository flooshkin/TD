using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BulletBehaviorSlow : BaseBullet
{
    [SerializeField]
    public List<GameObject> enemies;

    [SerializeField]
    public Color baseColor;
    [SerializeField]
    public Color slowColor;

    private ChangeSprite changeSprite;

    protected override int TowerDamageValue()
    {
        return damage;
    }
    
    protected override float TowerSlowValue()
    {
        return 1f;
    }
    
    void OnEnemyDestroy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var currentEnemy = other.gameObject;
        if (currentEnemy.tag.Equals("Enemy"))
        {
            // StartSlow(1f,1f, currentEnemy.GetComponent<MoveEnemy>());
            enemies.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            // TimeToSlow(currentEnemy);
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    // public void TimeToSlow(GameObject currentEnemy)
    // {
    //     StartSlow(5f,0.005f, currentEnemy.GetComponent<MoveEnemy>());
    // }

    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     var currentEnemy = other.gameObject;
    //     if (currentEnemy.tag.Equals("Enemy"))
    //     {
    //         StartSlow(5f,0.005f, currentEnemy.GetComponent<MoveEnemy>());
    //     }
    // }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemies.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    protected override void DoDamage(GameObject enemy, List<GameObject> enemiesInRange)
    {
        var tempList = new List<GameObject>();
        tempList.AddRange(enemies);
        foreach (var targetEnemy in tempList)
        {
            Transform healthBarTransform = targetEnemy.transform.Find("HealthBar");
            HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
            healthBar.currentHealth -= damage;
            if (healthBar.currentHealth <= 0)
            {
                Destroy(targetEnemy);
                GameObject dieEff = Instantiate(dieEffect, transform.position, Quaternion.identity);
                Destroy(dieEff,0.3f);
                AudioSource audioSource = targetEnemy.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                DropItemAfterDie();
                gameManager.Gold += gold;
                ScoreManager.score += score;
            }
        }
    }

    // public void StartSlow(float duration, float slowValue, MoveEnemy currentEnemy)
    // {
    //     if (currentEnemy.slowIsActive == false)
    //     {
    //         StartCoroutine(GetSlow(duration, slowValue, currentEnemy));
    //     }
    // }
    //
    // IEnumerator GetSlow(float duration, float slowValue, MoveEnemy currentEnemy)
    // {
    //     float oldSpeed = currentEnemy.startSpeed;
    //     currentEnemy.startSpeed -= slowValue;
    //     currentEnemy.slowIsActive = true;
    //     yield return new WaitForSeconds(duration);
    //     currentEnemy.startSpeed = oldSpeed;
    //     currentEnemy.slowIsActive = false;
    // }
}
