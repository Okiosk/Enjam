using UnityEngine;
using UnityEngine.InputSystem;
public class candy_box_script : MonoBehaviour
{
    private bool playerIn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("qdhsdg");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIn = false;
    }
}
