using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class BaseBullet: MonoBehaviour
{
    
    public float speed = 10;
    public int damage;
    public int gold = 10;
    public int score = 1;
   
    public Vector3 startPosition;
    public Vector3 targetPosition;
    
    public GameObject hitEffect;
    public GameObject dieEffect;
    
    public GameObject target;
    public List<GameObject> targetsList;
    public MoveEnemy moveEnemy;
    
    private float distance;
    private float startTime;
    

    protected GameManagerBehavior gameManager;

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
        
        // поворот снаряда в сторону врага
         // Vector2 dir = target.transform.position - transform.position;
         // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
         // transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                damage = TowerDamageValue();
                // moveEnemy.speed = TowerSlowValue();
                DoDamage(target, targetsList);
            }
            Destroy(gameObject);
            GameObject hitEff = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hitEff,0.3f);
        }
    }

    protected abstract int TowerDamageValue();
    
    protected abstract float TowerSlowValue();

    protected abstract void DoDamage(GameObject enemy, List<GameObject> enemiesInRange);
}