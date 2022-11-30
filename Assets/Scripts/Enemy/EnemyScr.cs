using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    public float MaxHealth;
    public int Bounty;
    [HideInInspector]
    public float Speed, Health, StartSpeed;

    public void Enemy(float health, float speed, int bounty)
    {
        MaxHealth = Health = health;
        StartSpeed = Speed = speed;
        Bounty = bounty;

    }

}
