using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BountyScr : MonoBehaviour
{
    public Color StartColor, EndColor;
    void Update()
    {
        if (GetComponent<Text>().color.a <= 0)
        {
            Destroy(gameObject);
            return;
        }
        GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, EndColor, Time.deltaTime * 6);
        transform.Translate(Vector3.up * Time.deltaTime * 2);
    }

    public void SetParams(int bounty)
    {
        GetComponent<Text>().text = "+" + bounty;
        GetComponent<Text>().color = StartColor;
    }
}
