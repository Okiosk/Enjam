using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class candy_box_script : MonoBehaviour
{

    public string typeCandy;
    private ui_le_script uiScript;

    private bool playerIn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiScript = GameObject.FindGameObjectWithTag("UI").GetComponent<ui_le_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                uiScript.changeIcone(typeCandy);
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
