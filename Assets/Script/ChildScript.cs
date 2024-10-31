using NUnit.Framework;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private int minTime = 10, maxTime = 10;
    private float childTimer = 0;
    private int waitingTime = 12;
    private float childWaitingTimer;
    public bool childIsWaiting = false;
    private string[] colors = {"orange","green","blue","pink"};
    public string color = "none";
    public bool mad = false;
    private int madProbability = 10;
    private bool playerLoosedLife = false;
    public SpriteRenderer childRenderer;
    public DoorScript door;
    public PlayerScript player;
    public ui_le_script _ui;
    public GameObject greenCandy;
    public GameObject CanneCandy;
    public GameObject DonutCandy;
    public GameObject sucetteCandy;
    public AudioSource NocNocSound;
    public AudioSource NOCNOCSound;
    
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<ui_le_script>();

        childTimer = Random.Range(minTime, maxTime+1);
        childRenderer.enabled = false;
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
                    childRenderer.enabled = true;
                    ChildWaitingAtTheDoor();
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
                ChildNoLongerWaitingAtTheDoor();
                
                if (playerLoosedLife)
                {
                    playerLoosedLife = false;
                }   
            }
        }
    }   
    public void ChildWaitingAtTheDoor()
    {
        childIsWaiting = true;
        childWaitingTimer = waitingTime;
        if (Random.Range(0, madProbability) == 0)
        {
            NOCNOCSound.Play();
            mad = true;
        }
        else
        {
            NocNocSound.Play();
            color = colors[Random.Range(0, colors.Length)];
        }
    }
    public void ChildNoLongerWaitingAtTheDoor()
    {
        if (!mad)
        {
            if (!playerLoosedLife)
            {
                madProbability -= 1;
                player.lives -= 1;
                playerLoosedLife = true;
            }
            if (door.isOpen)
            {
                door.ChangeDoorState();
            }
        }
        else
        {
            //the mad child is gone
        }
        ResetWaitingVars();
    }
    public bool GiveCandy()
    {
        if (player.candyCarry == "none")
        {
            Debug.Log("I have nothing to give.");
            return false;
        }
        else if (player.candyCarry == color)
        {      
            minTime -= 1;
            ResetWaitingVars();
        }
        else
        {
            if (!playerLoosedLife)
            {
                madProbability -= 1;
                player.lives -= 1;
                playerLoosedLife = true;
            }
            player.candyCarry = "none";
            _ui.changeIcon("none");
            return false;
        }
        player.candyCarry = "none";
        _ui.changeIcon("none");
        return true;
    }
    public void KillPlayer()
    {
        player.isDead = true;
    }
    private void ResetWaitingVars()
    {
        childIsWaiting = false;
        mad = false;
        color = "none";
        DisplayBubble("none");
        childRenderer.enabled = false;
        childTimer = Random.Range(minTime, maxTime+1);
    }
    public void DisplayBubble(string color)
    {
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
            case "none":
                sucetteCandy.SetActive(false);
                DonutCandy.SetActive(false);
                CanneCandy.SetActive(false);
                greenCandy.SetActive(false);
                break;
        }
    }
}
