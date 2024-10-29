using NUnit.Framework;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private int minTime = 10, maxTime = 15;
    private float childTimer = 0;
    private int waitingTime = 5;
    private float childWaitingTimer = 0;
    public bool childIsWaiting = false;
    private string[] colors = {"orange","vert","bleu","rose"};
    public string color = "";
    private bool mad = false;
    private int madProbability = 10;
    public DoorScript door;
    
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorScript>();
    }

    void Update()
    {
        if (!childIsWaiting)
        {    if (childTimer > 0)
            {
                childTimer -= 1 * Time.deltaTime;
            }
            else
            {
                if (!door.isOpen)
                {
                    Waiting();
                }
            }
        }
        else
        {    if (childWaitingTimer > 0)
            {
                childWaitingTimer -= 1 * Time.deltaTime;
            }
            else
            {
                NotWaiting();
            }
        }
    }
    public void Waiting()
    {
        childIsWaiting = true;
        childWaitingTimer = waitingTime;
        color = colors[Random.Range(0, colors.Length)];
        Debug.Log("THE "+ color +" CHILD IS WAITING !!!");
    }
    public void NotWaiting()
    {
        childIsWaiting = false;
        childTimer = Random.Range(minTime, maxTime);
        color = "";
        Debug.Log("THE "+color+" CHILD IS NO LONGER WAITING.");
    }
}
