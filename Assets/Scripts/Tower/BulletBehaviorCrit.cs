using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviorCrit : BaseBullet
{
    public GameObject critTxt;
    protected override int TowerDamageValue()
    {
        return CritDamage();
    }

    protected override float TowerSlowValue()
    {
        return moveEnemy.startSpeed;
    }
 
    public int CritDamage()
    {
        System.Random critical = new System.Random();
        var criticalDamage = critical.Next(1, 100);
        if (criticalDamage <= 100)
        {
            ShowCritTxt("crit");
            return damage * 2;

        }
        else
        {
            return damage;
        }

    }

    protected override void DoDamage(GameObject enemy, List<GameObject> enemiesInRange)
    {
        Transform healthBarTransform = target.transform.Find("HealthBar");
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

    public void ShowCritTxt(string crit)
    {
        // Vector3 startPosition = gameObject.transform.position;
        // critTxt.transform.position = startPosition;
        GameObject Txt = Instantiate(critTxt, transform.position, Quaternion.identity);
        Txt.transform.SetParent(GameObject.Find("Canvas").transform, true);
        Txt.GetComponent<CritTxt>().SetParams(crit);
    }
}
