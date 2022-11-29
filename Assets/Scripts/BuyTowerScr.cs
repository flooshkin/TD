using UnityEngine;

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


    public void OnClick()
    {
        towerScr.enabled = true;
        towerPanel.SetActive(false);
        Debug.Log("Click!");
    }

}
