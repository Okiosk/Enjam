using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class candy_box_script : MonoBehaviour
{

    public string typeCandy;
    private ui_le_script uiScript;
    private PlayerScript pScript;
    private camera_script camera;
    private bool inQTE = false;
    private int avancementQTE = 0;

    private bool playerIn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiScript = GameObject.FindGameObjectWithTag("UI").GetComponent<ui_le_script>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camera_script>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn) 
        {
            // Boite de bonbon
            if (Input.GetKeyDown(KeyCode.Space) && (pScript.candyCarry == "none" || typeCandy != "none"))
            {
                camera.doZoom(gameObject.transform.position.x, gameObject.transform.position.y);
                inQTE = true;
                pScript.inQTE = true;
            }
            // Poubelle
            if (Input.GetKeyDown(KeyCode.Space) && (pScript.candyCarry != "none" || typeCandy == "none"))
            {
                pScript.candyCarry = typeCandy;
                uiScript.changeIcon(typeCandy);
            }

            if (inQTE ) 
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    avancementQTE++;
                }


                if (avancementQTE == 3) 
                {
                    pScript.candyCarry = typeCandy;
                    uiScript.changeIcon(typeCandy);
                    camera.unzoom();
                    inQTE = false;
                    pScript.inQTE = false;
                }

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
