using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BuyTower : MonoBehaviour
{
    public List<GameObject> towersPrefabs;
    public List<Image> towersUI;
    public Transform spawnTowerRoot;
    private int spawnID = -1;
    public Tilemap spawnTilemap;
    public SpriteRenderer spriteTower;
    private TowerPlaceScr towerPlace;
    private GameManagerBehavior gameManager;
    public List<TowerScr> listOfTowers;
    
    private void Update()
    {
        if(CanSpawn())
            DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void DetectSpawnPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                SpawnTower(cellPosCentered);
                spawnTilemap.SetColliderType(cellPosDefault,Tile.ColliderType.None);
            }
        }
    }

    public void ActivateSpawnPoint()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
        spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.Sprite);
    }

    public void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;

        ChangeColor();
        DeselectTowers();
    }

    public void SelectTower(int id)
    {
        spawnID = id;
        towersUI[spawnID].color = Color.white;
    }

    public void DeselectTowers()
    {
        spawnID = -1;
        foreach (var touch in towersUI)
        {
            touch.color = new Color(255f, 255f, 255f, 170f);
        }
    }

    public void ChangeColor()
    {
        towersUI[spawnID].color = new Color(255f, 255f, 255f, 170f);
    }   

    public void AddPurchasedTower(TowerScr tower)
    {
        listOfTowers.Add(tower);
    }
}