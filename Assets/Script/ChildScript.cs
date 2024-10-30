using NUnit.Framework;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private int minTime = 10, maxTime = 15;
    private float childTimer = 0;
    private int waitingTime = 5;
    private float childWaitingTimer;
    public bool childIsWaiting = false;
    private string[] colors = {"orange","green","blue","pink"};
    public string color = "";
    private bool mad = false;
    private int madProbability = 10;
    public DoorScript door;
    public PlayerScript player;
    public ui_le_script _ui;
    
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<ui_le_script>();

        childTimer = Random.Range(minTime, maxTime+1);
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
                NotWaiting(false);
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
            Debug.Log("THE MAD CHILD IS WAITING, DON'T OPEN THE DOOR !");
        }
        else
        {
            color = colors[Random.Range(0, colors.Length)];
            Debug.Log("The "+ color +" child is waiting !");
        }
    }
    public void NotWaiting(bool opened)
    {
        if (opened)
        {
            if (mad)
            {    
                Debug.Log("YOU DIED !");
                //player.isDead = true;
            }
            else
            {
                if (player.candyCarry == color)
                {
                    ResetWaitingVars();
                    Debug.Log("You gived the good candy to the child !");
                }
                else
                {
                    ResetWaitingVars();
                    Debug.Log("You gived the wrong candy to the child !");
                }
                door.isOpen = false;
                player.candyCarry = "none";
                _ui.changeIcon("none");
                
            }
        }
        else      
        {
            if (!mad)
            {
                Debug.Log("The "+color+" child is going mad !");
            }
            else
            {
                Debug.Log("The mad child is gone.");
            }
        }
        ResetWaitingVars();
    }
    public void ResetWaitingVars()
    {
        childIsWaiting = false;
        mad = false;
        color = "none";
        childTimer = Random.Range(minTime, maxTime+1);
    }
}
