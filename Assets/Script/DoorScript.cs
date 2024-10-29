using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isOpen = !isOpen;
                Debug.Log("Door open is "+isOpen.ToString());
            }
    }
}
