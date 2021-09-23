using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{
    Animator anim; // поле аниматора
    Touch touch;    // поле нажатия
    
    void Start()
    {
        anim = GetComponent<Animator>(); // доступ к управлению анимаций
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0) // 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

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
}




