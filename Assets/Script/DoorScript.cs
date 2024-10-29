using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool playerOnDoor = false;
    private bool isOpen = false;
    private int screamerProbability = 10;
    public ChildScript child;
    public PlayerScript player;
    void Start()
    {
        child = GameObject.FindGameObjectWithTag("Child").GetComponent<ChildScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (playerOnDoor && Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDoorState();
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
    private void ChangeDoorState()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            if (child.childIsWaiting)
            {
                child.NotWaiting();
            }
            else
            {
                if (Random.Range(0, screamerProbability) == 0)
                {
                    //display the screamer
                    //play the sound
                }
                else
                {
                    //nothing append
                }
            }
        }
    }
}
