using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] BulletTank bullet;
    Vector3 velocity;
    Vector3 direction;
    float speed;

    Vector2 minScreen, maxScreen;
    private object steeringTank;

    void Start()
    {
        direction = transform.right;
        speed = 1.0f;

        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Debug.Log(minScreen + "" + maxScreen);
    }


    void Update()
    {
        MoveTank();
        BoxingScreen();
        SteeringTank();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))       
        {
            BulletTank ÍnstanceOfBullet = Instantiate(bullet, transform.position,Quaternion.identity);
            ÍnstanceOfBullet.Direction = direction;
        }
       

    }

    private void SteeringTank()
    {
        float Horizontal = -Input.GetAxis("Horizontal") * 1f;
        transform.Rotate(0, 0, Horizontal);
        direction = transform.right;

        float Vertical = Input.GetAxis("Vertical");
        speed += Vertical;

        speed = Mathf.Clamp(speed, 0.0f, 10.0f);
    }

    private void BoxingScreen()
    {
        Vector3 pos = transform.position;

        if (pos.x > maxScreen.x) { pos.x = minScreen.x; }
        if (pos.x < minScreen.x) { pos.x = maxScreen.x; }
        if (pos.y > maxScreen.y) { pos.y = minScreen.y; }
        if (pos.y < minScreen.y) { pos.y = maxScreen.y; }

        transform.position = pos;
      
    }

    private void MoveTank()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity; 
    }
}
