using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToAndFro : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;

    [SerializeField] Transform Player;

    Vector3 differenceVector;
    float distance;
    Vector3 direction;

    [SerializeField]  TextMeshProUGUI Stopwatch;
    float time = 0;
    float duration;


    bool FromAToB = true;
    void Start()
    {
       
        distance = differenceVector.magnitude;  
        Debug.Log(distance);

        Player.position = A.position;
    }

    void Update()
    {
        if (FromAToB)
        {
            differenceVector = B.position - A.position;
            Debug.Log(differenceVector);
       }
        else
        {
            differenceVector = A.position - B.position;
        }

        distance = differenceVector.magnitude;
        duration = distance / 1;
        direction = differenceVector.normalized;

        Player.position += direction * Time.deltaTime;  
        time += Time.deltaTime;
        Stopwatch.text = time.ToString("F3");

            if (time > duration)
            {
            FromAToB = !FromAToB;
            time = 0;
            }

        
    }
}
