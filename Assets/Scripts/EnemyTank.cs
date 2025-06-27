using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction;
    float speed;

    Vector2 minScreen;
    Vector2 maxScreen;

    Vector3 target;
    Vector3 differenceVector;

    float distance;
    
    enum State { begin, move, end }; //met enum kan je kijken 
    State myState = State.begin;

    float time;
    float duration;


    void Start()
    {
        direction = Vector3.right;
        speed = 1.0f;

        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
       
        target = choosePoint();
          moveToTarget();


    }

    void Update()
    {

        if (myState == State.begin)
        {
            time = 0; //

          target = choosePoint();
               moveToTarget();
            myState = State.move;
        }

        if (myState == State.move)
        {
         
            time += Time.deltaTime;
            if (time > duration)
            {
                myState = State.end;
            }

        }
        if (myState == State.end)
        {
           myState =State.begin;
        }
        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
    }


    private Vector3 choosePoint()
    {
        float xPos = Random.Range(minScreen.x, maxScreen.x);
        float yPos = Random.Range(minScreen.y, maxScreen.y);

        return new Vector3(xPos, yPos, 0);

    }

    void moveToTarget()
    {
        differenceVector = target -transform.position;
        distance = differenceVector.magnitude; // Magintude het veschil tussen twee posities
        direction = differenceVector.normalized; // normalized is als je de Vector is berekend en dan doet die dat keer 1. Dat helpt met als je speed wilt vermendigvuldigen
        transform.right = direction;
        duration = distance / speed;

        time = Time.deltaTime;
        if(time > duration)
        {
          myState = State.end;
        }
    }


    private void OnDrawGizmos() //Gizmos zijn hulp lijntjes om te controleren waar een punt zit
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, target);   
    }


}
