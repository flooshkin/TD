using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuyTowerScr : MonoBehaviour
{
    private TowerPlaceScr towerScr;
    public GameObject towerPanel;
    public GameObject towerPanelPrefab;
    public GameObject TowerPref;

    void Start()
    {
        //towerScr = towerPanelPrefab.GetComponent<TowerPlaceScr>();
    }


    void OnMouseDown()
    {
        towerScr.enabled = true;
        towerPanel.SetActive(false);
        Debug.Log("Click!");
    }

}
