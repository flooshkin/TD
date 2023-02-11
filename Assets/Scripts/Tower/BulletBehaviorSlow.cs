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
            // if (gameObject.transform.position.Equals(targetPosition))
            // {
            //     if (target != null)
            //     {
            //         var enemy = currentEnemy.GetComponent<MoveEnemy>();
            //         enemy.GetStartSlow();
            //     }
            // }

            enemies.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

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
            var target = targetEnemy.GetComponent<MoveEnemy>();
            target.GetStartSlow();
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
}
