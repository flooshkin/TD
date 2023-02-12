using JetBrains.Annotations;
using UnityEngine;
public class DropManager : MonoBehaviour
{
    public GameObject healthPrefab;
    public GameObject energyPrefab;
    public GameManagerBehavior gameManager;
    public int DropChance;
    private System.Random generator;
    private int maxHealth;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        generator = new System.Random();
        maxHealth = gameManager.Health;
    }

    public void DropItem(GameObject enemy)
    {
        if (ItemIsDropped())
        {
            var item = ItemForDrop();
            if (item != null)
            {
                Instantiate(item, enemy.transform.position, Quaternion.identity);
            }
        }
    }

    private bool ItemIsDropped()
    {
        var randomChance = generator.Next(0, 100);
        var isDropped = randomChance < DropChance;
        return isDropped;
    }

    [CanBeNull]
    private GameObject ItemForDrop()
    {
        var item = generator.Next(0, 2);
        switch (item)
        {
            case 0:
            {
                if (gameManager.Health < maxHealth)
                {
                    return healthPrefab;
                }
                else
                {
                    return null;
                }
            }
            case 1:
            {
                return energyPrefab;
            }
            default:
                return null;
        }
    }
}