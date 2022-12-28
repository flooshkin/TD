using UnityEngine;

public class ShopMenuScr : MonoBehaviour
{
    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;
    public GameObject Shop;

    public GameObject[] menuItems;

    private ShopMenuItemScr menuItemScr;
    private ShopMenuItemScr previousMenuItemScr;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }

        normalisedMousePosition = new Vector2 (Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2);
        currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 90;

        if(selection != previousSelection)
        {
            previousMenuItemScr = menuItems[previousSelection].GetComponent<ShopMenuItemScr>();
            previousMenuItemScr.Deselect();
            previousSelection = selection;

            menuItemScr = menuItems[selection].GetComponent<ShopMenuItemScr>();
            menuItemScr.Select();
        }

    }
    public static bool ShopOn = false;


    public void Resume()
    {
        Shop.SetActive(false);
        ShopOn = false;
    }

    public void ShopMenu()
    {
        Shop.SetActive(true);
        ShopOn = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void onClick()
    {
        Shop.SetActive(true);
        ShopOn = true;
    }
}
