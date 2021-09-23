using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float CoinSpeed = 14f;

    void FixedUpdate()
    {
        if (!GameControllerScript.instance.gameOver)
        {
            transform.position = (Vector2)transform.position + Vector2.left * CoinSpeed * Time.deltaTime;
        }

        if (transform.position.x <= -10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sword"))
        {
            GameControllerScript.instance.ScoreCoin();
            Destroy(gameObject);
            
        }
    }
}
