using UnityEngine;

public class CursorScr : MonoBehaviour
{
    public Sprite mainCursor, clickCursor;
    private SpriteRenderer rend;

    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if(Input.GetMouseButtonDown(0))
        {
            rend.sprite = clickCursor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rend.sprite = mainCursor;
        }
    }
}
