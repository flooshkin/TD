using UnityEngine;

public class SkillFullPower: MonoBehaviour
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
    private BuyTower shop;
    private float AttackSpeedValue = 0.5f;

    void Start()
    {
        shop = GameObject.Find("Shop").GetComponent<BuyTower>();
        var list = shop.listOfTowers;
        for (int i = 0; i < list.Count; i++)
        {
            var tower = list[i];
            tower.CurrentLevel.fireRate -= AttackSpeedValue;
        }
    }

    private void OnDestroy()
    {
        var list = shop.listOfTowers;
        for (int i = 0; i < list.Count; i++)
        {
            var tower = list[i];
            tower.CurrentLevel.fireRate += AttackSpeedValue;
        }
    }
}