using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;
    private float[] velocity = {0,0};
    public string candyCarry = "none";
    public int lives = 5;
    public bool isDead = false;
    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            isDead = true;
        }
        velocity[0] = 0;
        velocity[1] = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity[0] += speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity[0] -= speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity[1] += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity[1] -= speed;
        }
        rigidBody.linearVelocity = new Vector2(velocity[0], velocity[1]) * Time.deltaTime;
    }
}
