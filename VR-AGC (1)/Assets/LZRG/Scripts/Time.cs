using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Time : MonoBehaviour
{
    public float timeRemaining = 10;

    public bool timerIsRunning = false;

    private void Start()
    {
        
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= UnityEngine.Time.deltaTime;
            }
            else
            {
                Debug.Log("Time out");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    
    //the object to collide with to start the timer must have the tag Timecollide (bedloh ida habito)

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Timer started");
            timerIsRunning = true;

        }
    }
}