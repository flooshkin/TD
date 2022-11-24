using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float Timer = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
