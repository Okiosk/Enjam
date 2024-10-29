using NUnit.Framework;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private int minTime = 1, maxTime = 1;
    private float childTimer = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (childTimer > 0)
        {
            childTimer -= 1 * Time.deltaTime;
        }
        else
        {
            childTimer = Random.Range(minTime, maxTime);
            Debug.Log("add child");
        }
    }
}
