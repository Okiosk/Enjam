using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)) 
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
}
