using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTank : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = Vector3.right;
    float speed = 15.0f;

    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
    }
}
