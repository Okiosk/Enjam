
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class replayScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
}
