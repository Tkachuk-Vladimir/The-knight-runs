using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    public GameObject[] Coins;
    
    float x = -8f;
    float y = 5f;

    void Start()
    {
        for (int v = 0; v < 5; v++)
        {
            for (int i = 0; i < 5; i++)
            {
              Instantiate(Coins[v], new Vector2(x, y), Quaternion.identity);
              x = x + 1.2f;
            }
            y = y - 1.4f;
            x = -8f;
        }

    }

    void Update()
    {
       
    }
}
/*
public GameObject[] Tools;          
for (int v = 0; v < 5; v++)
{
    for (int i = 0; i < 5; i++)
    {
        Instantiate(Tools[i], new Vector2(x, y), Quaternion.identity);
        x = x + 1.2f;
    }
    x = -8f;
    y = y - 1.4f;
}
*/
