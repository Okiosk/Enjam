using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool playerOnDoor = false;
    private bool isOpen = false;
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
                
            }
        }
    }
}
