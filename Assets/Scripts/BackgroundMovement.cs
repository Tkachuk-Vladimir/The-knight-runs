using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float scrollSpeed; // скорость движения environment
    //public Joystick joystick;

    private BoxCollider2D groundCollider; // поле BoxCollider2D
    private float groundHorizontalLenght; // длина BoxCollider2D

    

    Rigidbody2D RbGameObject; // поле RB
    Vector2 gameObjectOffSet; // вектор премещения
   
    //bool isCreated = false;
  
    void Start()
    {
        RbGameObject = GetComponent<Rigidbody2D>(); // получаем доступ к Rigidbody2D
        groundCollider = GetComponent<BoxCollider2D>(); // получаем доступ к BoxCollider2D
        groundHorizontalLenght = groundCollider.size.x; // находим длину  BoxCollider2D

    }

    void FixedUpdate()
    {
        //if (!PlayerControl.collisionRock)
        if (!GameControllerScript.instance.gameOver)
        {
            RbGameObject.MovePosition(RbGameObject.position + Vector2.left * scrollSpeed * Time.deltaTime); // движение влево
        }

        if (transform.position.x <= -groundHorizontalLenght)
        {
            RepositionGameObjectLeft();
        }
    }

    private void RepositionGameObjectLeft()
    {
        gameObjectOffSet = new Vector2(groundHorizontalLenght * 2f, 0); // создаём вектор переноса
        transform.position = (Vector2)transform.position + gameObjectOffSet; // к позиции обьекта прибавляем вектор переноса,
    }
    private void RepositionGameObjectRight()
    {
        gameObjectOffSet = new Vector2(-groundHorizontalLenght * 2f, 0);
        transform.position = (Vector2)transform.position + gameObjectOffSet;
    }

}
