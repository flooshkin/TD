using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScr : MonoBehaviour
{
    public GameObject towerPanel;
    [SerializeField]
    Button towerShop;
    TowerPlaceScr TowerPlaceScr;
    public bool shopPlace;

    void Start()
    {
        //towerShop.onClick.AddListener(Shop);
    }

    void Shop()
    {
        Instantiate(towerPanel);
    }

    void OnMouseUp()
    {
        
    }

    void OnMouseDown()
    {
        towerPanel.SetActive(true);
        if (!shopPlace && TowerPlaceScr.tower == null)
            if (!towerPanel)
                towerPanel.SetActive(true);
            else
                towerPanel.SetActive(false);
    }

}
