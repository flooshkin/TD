using UnityEngine;
using UnityEngine.UI;

public class CritTxt : MonoBehaviour
{
    public Color StartColor, EndColor;
    void Update()
    {
        Object.Destroy(gameObject, 1f);
        // if (GetComponent<Text>().color.a <= 10)  
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, EndColor, Time.deltaTime * 6);
        transform.Translate(Vector3.up * Time.deltaTime * 2);
    }

    public void SetParams(string crit)
    {
        GetComponent<Text>().text = "crit";
        GetComponent<Text>().color = StartColor;
    }
}