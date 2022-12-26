using UnityEngine;

public class TowerPlaceScr : MonoBehaviour
{
    
    public GameObject towerPrefab;
    public GameObject tower;
    private GameManagerBehavior gameManager;

    Tooltip tooltip;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    private bool CanPlaceMonster()
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
        if (CanPlaceMonster())
        {
            tower = (GameObject) Instantiate(towerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);
        
            gameManager.Gold -= tower.GetComponent<TowerScr>().CurrentLevel.cost;
        }
        else if (CanUpgradeMonster())
        {
            tower.GetComponent<TowerScr>().IncreaseLevel();
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            gameManager.Gold -= tower.GetComponent<TowerScr>().CurrentLevel.cost;
        }
    }

    private bool CanUpgradeMonster()
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
}
