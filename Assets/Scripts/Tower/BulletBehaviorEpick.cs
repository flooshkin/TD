using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviorEpick : BaseBullet
{
    protected override int TowerDamageValue()
    {
        return damage;
    }
    
    protected override float TowerSlowValue()
    {
        return moveEnemy.speed;
    }

    protected override void DoDamage(GameObject enemy, List<GameObject> enemiesInRange)
    {
        Transform healthBarTransform = enemy.transform.Find("HealthBar");
        HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
        healthBar.currentHealth -= damage;
        if (healthBar.currentHealth <= 0)
        {
            Destroy(target);
            GameObject dieEff = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(dieEff,0.3f);
            AudioSource audioSource = target.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            DropItemAfterDie();
            gameManager.Gold += gold;
            ScoreManager.score += score;
        }
    }
}