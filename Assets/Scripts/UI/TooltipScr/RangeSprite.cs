using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class RangeSprite : MonoBehaviour
{

    public Sprite[] guessSprites;
    public Sprite mainSprite;
    private SpriteRenderer tokenSprites;

    void Start()
    {
        tokenSprites = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        tokenSprites.sprite = guessSprites[1];
        Debug.Log("навел");
    }

    void OnMouseExit()
    {
        tokenSprites.sprite = mainSprite;
        Debug.Log("отвел");
    }
}