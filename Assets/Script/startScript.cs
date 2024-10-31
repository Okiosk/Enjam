using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class startScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("sdsdsdsdsdsdsdsdsdsdsdsd");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) 
        {
            Debug.Log("qrrgzesg");
            SceneManager.LoadScene("Scenes/SampleScene");
        }

    }
    public void change()
    {

        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
