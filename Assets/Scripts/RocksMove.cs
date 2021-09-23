using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksMove : MonoBehaviour
{
    public float rockSpeed;

    private BoxCollider2D rockCollider; // поле BoxCollider2D
    private float rockHorizontalLenght; // длина BoxCollider2D
    private Rigidbody2D RbRock; // поле RB

    
    void Start()
    {
        RbRock = GetComponent<Rigidbody2D>(); // получаем доступ к Rigidbody2D
        rockCollider = GetComponent<BoxCollider2D>(); // получаем доступ к BoxCollider2D
        rockHorizontalLenght = rockCollider.size.x; // находим длину  BoxCollider2D
    }

    void FixedUpdate()
    {
        if (GameControllerScript.instance.gameOver == false)
        {
            transform.position = (Vector2)transform.position + Vector2.left * rockSpeed * Time.deltaTime;
            // RbRock.MovePosition(RbRock.position + Vector2.left * rockSpeed * Time.deltaTime); // движение влево
        }

        if (transform.position.x <= -rockHorizontalLenght * 10f)
        {
            Destroy(gameObject);
        }
    }
}
