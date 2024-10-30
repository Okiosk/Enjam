using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections.Generic;

public class ChildScript : MonoBehaviour
{
    private int minTime = 10, maxTime = 10;
    private float childTimer = 0;
    private int waitingTime = 8;
    private float childWaitingTimer;
    public bool childIsWaiting = false;
    private string[] colors = {"orange","green","blue","pink"};
    private string color = "";
    private bool mad = false;
    private int madProbability = 10;
    private bool playerLoosedLife = false;
    public DoorScript door;
    public PlayerScript player;
    public ui_le_script _ui;
    public GameObject greenCandy;
    public GameObject CanneCandy;
    public GameObject DonutCandy;
    public GameObject sucetteCandy;
    
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
        {   
            if (childTimer > 0)
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
        {   
            if (childWaitingTimer > 0)
            {
                childWaitingTimer -= 1 * Time.deltaTime;
            }
            else
            {
                NotWaiting(false);
                sucetteCandy.SetActive(false);
                DonutCandy.SetActive(false);
                CanneCandy.SetActive(false);
                greenCandy.SetActive(false);
                if (playerLoosedLife)
                {
                    playerLoosedLife = false;
                }   
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
            switch (color)
            {
                case "orange":
                    sucetteCandy.SetActive(true);
                    break;
                case "pink":
                    DonutCandy.SetActive(true);
                    break;
                case "blue":
                    CanneCandy.SetActive(true);
                    break;
                case "green":
                    greenCandy.SetActive(true);
                    break;
            }
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
                player.isDead = true;
            }
            else
            {
                if (player.candyCarry == "none")
                {
                    Debug.Log("I have nothing to give.");
                }
                else if (player.candyCarry == color)
                {
                    
                    Debug.Log("You gived the good candy to the child !");
                    door.isOpen = false;
                    minTime -= 1;
                    ResetWaitingVars();
                }
                else
                {
                    Debug.Log("You gived the wrong candy to the child !");
                    if (!playerLoosedLife)
                    {
                        madProbability -= 1;
                        playerLoosedLife = true;
                        Debug.Log("YOU LOOSED ONE LIFE !");
                    }
                }
                player.candyCarry = "none";
                _ui.changeIcon("none");
            }
        }
        else      
        {
            if (!mad)
            {
                Debug.Log("The "+color+" child is going mad !");
                if (!playerLoosedLife)
                {
                    madProbability -= 1;
                    playerLoosedLife = true;
                    Debug.Log("YOU LOOSED ONE LIFE !");
                }
                door.isOpen = false;
                ResetWaitingVars();
            }
            else
            {
                Debug.Log("The mad child is gone.");
                ResetWaitingVars();
            }
        }
    }
    private void ResetWaitingVars()
    {
        childIsWaiting = false;
        mad = false;
        color = "none";
        childTimer = Random.Range(minTime, maxTime+1);
    }
}
