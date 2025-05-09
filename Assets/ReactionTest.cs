using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionTest : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button StopButton;
    [SerializeField] Button ContinueButton;
    
    [SerializeField] TextMeshProUGUI StopWatch;

    enum State { idle, wait, start , stop };
    State myState = State.idle;
    float time;
    float timeTreshhold;
    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
        StopButton.onClick.AddListener(OnStopButtonClick);
        ContinueButton.onClick.AddListener(OnContinueButtonClick);
        UpdateUI();

        StopWatch.text = "";
    }

   
    void Update()
    {
        print (myState);
        if (myState == State.wait) { 
        
        time += Time.deltaTime;
            StopWatch.text = time.ToString ("F3");
        }
        if (time > timeTreshhold)
        {
            myState = State.start;
            time = 0;
           UpdateUI();  
        }


        if(myState == State.start)
        {
            time += Time.deltaTime;
            StopWatch.text = time.ToString("F3");
            

        }
    }
    void OnStartButtonClick()
    {
       // print("op start geklikt");
       myState = State.wait;
        timeTreshhold = Random.Range(2, 5);

    }
    void OnStopButtonClick() {

        print("stop");
        myState = State.stop;
    }

    void OnContinueButtonClick() {

        print("continue");
        myState = State.idle ;
    }
    void UpdateUI()
    {
        StartButton.gameObject.SetActive(myState == State.idle);
        StopButton.gameObject.SetActive(myState == State.start);
        ContinueButton.gameObject.SetActive(myState == State.stop);
        
    }
}
