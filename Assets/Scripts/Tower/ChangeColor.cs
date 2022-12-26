using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor:MonoBehaviour
{
    public Color StartColor, EndColor;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            sprite.color = new Color(0.57f, 0.84f, 1f); 
        }
        
        // GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, EndColor, Time.deltaTime * 6);
        // transform.Translate(Vector3.up * Time.deltaTime * 2);
    }

    // public void SetParams(int bounty)
    // {
    //     GetComponent<Text>().color = StartColor;
    // }
}
