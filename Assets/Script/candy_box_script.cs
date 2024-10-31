using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class candy_box_script : MonoBehaviour
{

    public string typeCandy;
    public TextMeshProUGUI uiGO;
    public Animator animator;

    private ui_le_script uiScript;
    private PlayerScript pScript;
    private camera_script camera;
    private bool inQTE = false;
    private int avancementQTE = 0;

    private bool start_timer = false;
    private float timer = 0;

    private int qte1 = 0;
    private int qte2 = 0;
    private int qte3 = 0;
    private List<KeyCode> listInput = new List<KeyCode>() 
    { KeyCode.A,
      KeyCode.Z,
      KeyCode.E,
      KeyCode.R,
      KeyCode.T,
      KeyCode.Y,
      KeyCode.U,
      KeyCode.I,
      KeyCode.O,
      KeyCode.P,
      KeyCode.Q,
      KeyCode.S,
      KeyCode.D,
      KeyCode.F,
      KeyCode.G,
      KeyCode.H,
      KeyCode.J,
      KeyCode.K,
      KeyCode.L,
      KeyCode.M,
      KeyCode.W,
      KeyCode.X,
      KeyCode.C,
      KeyCode.V,
      KeyCode.B,
      KeyCode.N,
    };
    private List<string> listInputName = new List<string>()
    { "A",
      "Z",
      "E",
      "R",
      "T",
      "Y",
      "U",
      "I",
      "O",
      "P",
      "Q",
      "S",
      "D",
      "F",
      "G",
      "H",
      "J",
      "K",
      "L",
      "M",
      "W",
      "X",
      "C",
      "V",
      "B",
      "N",
    };

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
        if (start_timer)
        {
            timer += Time.deltaTime;
        }
        if (timer > 1)
        {
            animator.SetBool("anim_play", false);
        }


        if (playerIn && !inQTE) 
        {

            // Boite de bonbon
            if (Input.GetKeyDown(KeyCode.Space) && pScript.candyCarry == "none" && typeCandy != "none")
            {
                pScript.inQTE = true;
                camera.doZoom(gameObject.transform.position.x, gameObject.transform.position.y);
                inQTE = true;
                createQTE();
                uiGO.text = listInputName[qte1] + listInputName[qte2] + listInputName[qte3];
            }
            // Poubelle
            if (Input.GetKeyDown(KeyCode.Space) && pScript.candyCarry != "none" && typeCandy == "none")
            {
                pScript.candyCarry = typeCandy;
                uiScript.changeIcon(typeCandy);
            }
        }
        if (inQTE)
        {
            if (avancementQTE == 0)
            {
                if (Input.GetKeyDown(listInput[qte1]))
                {
                    avancementQTE = 1;
                    uiGO.text = "  " + listInputName[qte2] + listInputName[qte3];
                }
            }
            if (avancementQTE == 1)
            {
                if (Input.GetKeyDown(listInput[qte2]))
                {
                    avancementQTE = 2;
                    uiGO.text = "    " + listInputName[qte3];
                }
            }
            if (avancementQTE == 2)
            {
                if (Input.GetKeyDown(listInput[qte3]))
                {
                    avancementQTE = 3;
                    uiGO.text = "";
                }
            }
            if (avancementQTE == 3)
            {
                pScript.candyCarry = typeCandy;
                uiScript.changeIcon(typeCandy);
                camera.unzoom();
                inQTE = false;
                pScript.inQTE = false;
                avancementQTE = 0;
                timer = 0;
                start_timer = true;
                animator.SetBool("anim_play",true);
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
    
    private void createQTE()
    {
        qte1 = Random.Range(0, 25);
        qte2 = Random.Range(0, 25);
        qte3 = Random.Range(0, 25);
    }
}
