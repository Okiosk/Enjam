using NUnit.Framework;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private int minTime = 10, maxTime = 15;
    private float childTimer = 0;
    private int waitingTime = 5;
    private float childWaitingTimer = 0;
    public bool childIsWaiting = false;
    private string[] colors = {"orange","green","blue","pink"};
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
        if (Random.Range(0, madProbability) == 0)
        {
            mad = true;
            Debug.Log("THE MAD CHILD IS WAITING !!!");
        }
        else
        {
            color = colors[Random.Range(0, colors.Length)];
            Debug.Log("THE "+ color +" CHILD IS WAITING !!!");
        }
    }
    public void NotWaiting()
    {
        childIsWaiting = false;
        childTimer = Random.Range(minTime, maxTime);
        color = "";
        mad = false;
        Debug.Log("THE "+color+" CHILD IS NO LONGER WAITING.");
    }
}
