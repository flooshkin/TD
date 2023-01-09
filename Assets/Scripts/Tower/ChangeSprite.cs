using System.Collections;
using UnityEngine;

public class ChangeSprite: MonoBehaviour
{
    public SpriteRenderer sprite;
    public Color slowColor;

    public void ChangeColor()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = slowColor;
        // StartCoroutine(SpriteSlowActive(1f));
    }
    
    IEnumerator SpriteSlowActive(float duration)
    {
        duration = 1f;
        yield return new WaitForSeconds(duration);
    }
}
