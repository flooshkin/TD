using UnityEngine;

public class TowerPlaceScr : MonoBehaviour
{
    
    public GameObject towerPrefab;
    public GameObject tower;
    private GameManagerBehavior gameManager;
    private BuyTower shop;
    private Tutorial mainCamera;

    Tooltip tooltip;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        shop = GameObject.Find("Shop").GetComponent<BuyTower>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Tutorial>();
    }

    private bool CanPlaceTower()
    {
        if (tower != null)
        {
            Tooltip.show = false;
        }
        int cost = towerPrefab.GetComponent<TowerScr>().levels[0].cost;
        return tower == null && gameManager.Gold >= cost;
    }

    void OnMouseUp()
    {
        if (Tutorial.RemoveButtonSelected)
        {
            SellTower();
            return;
        }
        if (CanPlaceTower())
        {
            tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            shop.AddPurchasedTower(tower.GetComponent<TowerScr>());
            gameManager.Gold -= tower.GetComponent<TowerScr>().CurrentLevel.cost;
        }
        else if (CanUpgradeTower())
        {
            tower.GetComponent<TowerScr>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
            shop.AddPurchasedTower(tower.GetComponent<TowerScr>());
            gameManager.Gold -= tower.GetComponent<TowerScr>().CurrentLevel.cost;
        }
    }

    private bool CanUpgradeTower()
    {
        if (tower != null)
        {
            TowerScr TowerScr = tower.GetComponent<TowerScr>();
            TowerLevel nextLevel = TowerScr.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Gold >= nextLevel.cost;
            }
        }
        return false;
    }

    public void Select()
    {
    }

    private void SellTower()
    {
        Destroy(tower);
        Destroy(gameObject);
        gameManager.Gold += tower.GetComponent<TowerScr>().CurrentLevel.cost;
        shop.ActivateSpawnPoint();
        mainCamera.DeactivateRemoveState();
    }
}
