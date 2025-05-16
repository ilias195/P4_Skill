using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = new Vector3(1, 2, 0);
    float speed = 3;

    Vector2 minScreen, maxScreen;
    void Start()
    {
        direction = direction.normalized;
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }


    void Update()
    {
        velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;

        if (transform.position.y > maxScreen.y -transform.localScale.y/2) { direction.y = -direction.y; }
        if (transform.position.x > maxScreen.x - transform.localScale.x / 2) direction.x = -direction.x; 


        if (transform.position.y < minScreen.y + transform.localScale.y / 2) { direction.y = -direction.y; }
        if (transform.position.x < minScreen.x + transform.localScale.x / 2) { direction.x = -direction.x; }

       // if (transform.position.y > minScreen.y) { direction.y = -direction.y; }
       // if (transform.position.x > minScreen.x) direction.x = -direction.x;




    }
}
   

    

