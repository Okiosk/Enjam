using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;
    private float[] velocity = {0,0};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity[0] = 0;
        velocity[1] = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity[0] += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity[0] -= 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity[1] += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity[1] -= 1;
        }
        rigidBody.linearVelocity = new Vector2(velocity[0], velocity[1]);
    }
}
