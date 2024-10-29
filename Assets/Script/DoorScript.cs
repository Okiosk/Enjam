using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool playerOnDoor = false;
    private bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
        Debug.Log("Door open state is "+isOpen.ToString());
    }
}
