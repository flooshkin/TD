using UnityEngine;
using System.Collections.Generic;

public class BulletBehaviorAOE : BaseBullet
{
    public List<GameObject> enemies;

    protected override int TowerDamageValue()
    {
        return damage;
    }
    
    protected override float TowerSlowValue()
    {
        return damage;
    }
    
    void OnEnemyDestroy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
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
