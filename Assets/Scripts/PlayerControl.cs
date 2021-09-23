using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] bool swipJumpAllowed; // разрешение на прыжок
    [SerializeField] bool jumpAllowed; // разрешение на прыжок
    [SerializeField] KeyCode jumpButton; // назначаем клавишу для прыжка

    public float jumpForce; // устанавливаем силу прыжка
    public static bool collisionRock = false;

    float h; // axisRaw "horizont" 
   
    Animator anim;  // поле аниматор
    Touch touch;    // поле нажатия
    Vector2 endTouchPosition, startTouchPosition; // точки нажатия пальцем и 
    Rigidbody2D rb; // поле  Rigidbody

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

       h = Input.GetAxisRaw("Horizontal");
       SwipeCheck();

    }

    void FixedUpdate()
    {
       // Walking(h);
       // Hit();
       // Jump();

        if(transform.position.x <= -10.6f || transform.position.x >= 10.6f)
        {
            GameControllerScript.instance.GameOver();
        }
        
         if (GameControllerScript.instance.gameOver == false)
         {
             Walking(h);
             Hit();
             Jump();
             anim.SetBool("isWalking", true);
         }
         else
         {
             anim.SetBool("isWalking", false);
         }
        
    }

    void Walking(float h)
    {
        if (h > 0) // 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("isWalking", true);
            transform.position += transform.right * 5f * Time.deltaTime;
        }
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);  
            transform.position += transform.right * 5f * Time.deltaTime;
            anim.SetBool("isWalking", true);
            //rb.MovePosition(rb.position + Vector2.left * 5f * Time.deltaTime); // движение влево
        }
        if (h == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Hit()
    {
        if (Input.GetMouseButtonDown(0))  // устови на нажатие мышки
        {
            anim.SetTrigger("isHit");//включаем анимацию
        }
        if (Input.touchCount > 0)// условие нажатия тачскрина
        {
            //Debug.Log("isTouch");
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)//условие на простое нажатие
                anim.SetTrigger("isHit");
        }
    }

    void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
                swipJumpAllowed = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpAllowed = true;
        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            //collisionRock = true;
            GameControllerScript.instance.GameOver();
        }
       
    }
     
    void Jump()
    {
        if (swipJumpAllowed && jumpAllowed)
        {
            rb.AddForce(transform.up * jumpForce); // применяем силу в направлении вверх
            jumpAllowed = false; // выключаем возможность прыжка
            swipJumpAllowed = false; // выключаем возможность прыжка
            anim.SetTrigger("isJamp");
        }
        
        if (Input.GetKey(jumpButton) && jumpAllowed)
        {
            rb.AddForce(transform.up * jumpForce);
            anim.SetTrigger("isJump");
            jumpAllowed = false;
        }

    }
    
}
