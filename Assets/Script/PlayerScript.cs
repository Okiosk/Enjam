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
        animator.SetBool("moving", false);
        animator.SetFloat("x", velocity[0]);
        animator.SetFloat("y", velocity[1]);
        if (lives <= 0)
        {
            isDead = true;
        }

        if (!inQTE)
        {
            velocity[0] = 0;
            velocity[1] = 0;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                velocity[0] += speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }   
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                velocity[0] -= speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                velocity[1] += speed;
                animator.SetBool("moving", true);
                animator.SetFloat("lastDirX", velocity[0]);
                animator.SetFloat("lastDirY", velocity[1]);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                velocity[1] -= speed;
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
}
