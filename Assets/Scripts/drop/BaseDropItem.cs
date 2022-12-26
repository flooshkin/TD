using System.Collections;
using UnityEngine;

public class BaseDropItem : MonoBehaviour
{
    private Rigidbody2D rigibody;
    private const float DropForce = 3;
    public GameManagerBehavior gameManager;
    private const float TimeToStopItemAnimation = 0.5f;
    private float currentTime;
    private System.Random generator;
    protected bool IsPickedUp = false;
    private const float FlashingInterval = 0.3f;


    protected virtual void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > TimeToStopItemAnimation)
        {
            rigibody.bodyType = RigidbodyType2D.Static;
        }
    }
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        rigibody = GetComponent<Rigidbody2D>();
        generator = new System.Random();
        var item = generator.Next(0, 1);
        int itemDropSide;
        if (item == 1)
        {
            itemDropSide = -45;
        }
        else
        {
            itemDropSide = 45;
        }
        Quaternion rotation = Quaternion.Euler(0, 0, itemDropSide);
        rigibody.AddForce(rotation * Vector2.up * DropForce, ForceMode2D.Impulse);
        StartCoroutine(WaitAndDestroy(7));
        StartCoroutine(FlashSprite());
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Destroy(gameObject);
        }
    }
    
    private IEnumerator FlashSprite()
    {
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(3f);
        while(true)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(FlashingInterval);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(FlashingInterval);
        }
    }
}