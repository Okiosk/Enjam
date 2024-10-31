using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rigidBody;
    public float speed;
    private float[] velocity = {0,0};
    public string candyCarry = "none";
    public int lives = 5;
    public float winTimer = 5;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;
    public bool isDead = false;
    public bool inQTE = false;
    void Start()
    {

    }
    void Update()
    {
        if (winTimer > 0)
        {
            winTimer -= 1 * Time.deltaTime / 60; 
        }
        else
        {
            //win
        }
        animator.SetBool("moving", false);
        animator.SetFloat("x", velocity[0]);
        animator.SetFloat("y", velocity[1]);
        displayHearts(lives);

        if (!inQTE)
        {
            velocity[0] = 0;
            velocity[1] = 0;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;  
                velocity[0] = speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }   
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                velocity[0] = -speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                velocity[1] = speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                velocity[1] = -speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }
            rigidBody.linearVelocity = new Vector2(velocity[0], velocity[1]) * Time.deltaTime;
        }
        else 
        {
            rigidBody.linearVelocity = new Vector2(0, 0);
        }
    }
    void displayHearts(int value)
    {
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
        heart4.SetActive(false);
        heart5.SetActive(false);
        switch (value)
        {
            case 0:
                isDead = true;
                break;
            case 1:
                heart1.SetActive(true);
                break;
            case 2:
                heart1.SetActive(true);
                heart2.SetActive(true);
                break;
            case 3:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                break;
            case 4:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                break;
            case 5:
                heart1.SetActive(true);
                heart2.SetActive(true);
                heart3.SetActive(true);
                heart4.SetActive(true);
                heart5.SetActive(true);
                break;
        }
    }
}
