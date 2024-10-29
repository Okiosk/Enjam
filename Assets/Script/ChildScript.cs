using NUnit.Framework;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private int minTime = 10, maxTime = 15;
    private float childTimer = 0;
    private int waitingTime = 5;
    private float childWaitingTimer = 0;
    public bool childWaiting = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (childTimer > 0)
        {
            childTimer -= 1 * Time.deltaTime;
        }
        else
        {
            Waiting();
        }
        if (childWaitingTimer > 0)
        {
            childWaitingTimer -= 1 * Time.deltaTime;
        }
        else
        {
            NotWaiting();
        }
    }
    public void Waiting()
    {
        childWaiting = true;
        childWaitingTimer = waitingTime;
        Debug.Log("THE CHILD IS WAITING !!!");
    }
    public void NotWaiting()
    {
        childWaiting = false;
        childTimer = Random.Range(minTime, maxTime);
        Debug.Log("THE CHILD IS NO LONGER WAITING.");
    }
}
