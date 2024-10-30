using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool playerOnDoor = false;
    public bool isOpen = false;
    private int screamerProbability = 10;
    public ChildScript child;
    public GameObject openDoor;
    public SpriteRenderer _renderer;
    void Start()
    {
        child = GameObject.FindGameObjectWithTag("Child").GetComponent<ChildScript>();
    }

    void Update()
    {
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
                            Debug.Log("SCREAMER !!!!");
                        }
                        else
                        {
                            Debug.Log("There's nothing there...");
                        }
                    }
                }
                else
                {
                    if (isOpen)
                    {
                        if (child.mad)
                        {
                            child.KillPlayer();
                        }
                        else if (child.GiveCandy())
                        {
                            ChangeDoorState();
                        }
                    }
                    else
                    {
                        ChangeDoorState();
                    }
                }
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
    }
}
