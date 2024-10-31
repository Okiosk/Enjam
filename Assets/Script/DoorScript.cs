using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Animator animator;
    private bool playerOnDoor = false;
    public bool isOpen = false;
    private int screamerProbability = 10;
    private float screamerTimer;
    private int maxDoorTimer = 3;
    private float doorTimer;
    public AudioSource OpenDoorSound;
    public AudioSource CloseDoorSound;
    public GameObject Screamer;
    public ChildScript child;
    public GameObject openDoor;
    public SpriteRenderer _renderer;
    void Start()
    {
        child = GameObject.FindGameObjectWithTag("Child").GetComponent<ChildScript>();
        doorTimer = maxDoorTimer;
    }

    void Update()
    {
        /*if (Screamer.activeSelf && screamerTimer)
        {
            sreamerTimer -= 1 * Time.deltaTime;
        }
        else
        {
            Screamer.SetActive(false);
        }*/



        if (child.childIsWaiting)
        {
            if (child.childWaitingTimer > 11)
            {
                if (child.mad)
                {
                    animator.SetBool("knock_angry", true);
                }
                else
                {
                    animator.SetBool("knock_normal", true);
                }
            }
            else
            {
                animator.SetBool("knock_normal", false);
                animator.SetBool("knock_angry", false);
            }

        }

        

        if (isOpen || !child.childIsWaiting)
        {
            animator.SetBool("knock_normal", false);
            animator.SetBool("knock_angry", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerOnDoor)
            {
                if (!child.childIsWaiting)
                {
                    ChangeDoorState();
                    if (isOpen)
                    {
                        if (Random.Range(0, screamerProbability) == 0)
                        {
                            //display the screamer
                            //play the sound
                            /*Screamer.SetActive(true);*/
                            screamerTimer = 2;
                        }
                        else
                        {
                            //there is nothing here
                        }
                    }
                }
                else
                {
                    if (isOpen) // action when the door is open
                    {
                        if (child.GiveCandy())
                        {
                            ChangeDoorState();
                        }
                    }
                    else // action when you open the door
                    {
                        ChangeDoorState();
                        child.DisplayBubble(child.color);
                        if (child.mad)
                        {
                            child.KillPlayer();
                        }
                    }
                }
            }
        }
        if (isOpen && !child.childIsWaiting)
        {    
            if (doorTimer > 0)
            {
                doorTimer -= 1 * Time.deltaTime;
            }
            else
            {
                doorTimer = maxDoorTimer;
                ChangeDoorState();
            }
        }   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.name == "Player")
       {
            playerOnDoor = true;
       }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.name == "Player")
       {
            playerOnDoor = false;
       }
    }
    public void ChangeDoorState()
    {
        isOpen = !isOpen;
        openDoor.SetActive(isOpen);
        _renderer.enabled = !isOpen;
        if (isOpen)
            OpenDoorSound.Play();
        else
            CloseDoorSound.Play();
    }
}
