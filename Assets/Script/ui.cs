using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{
    public Image icone;
    public string typebonbon = "none";

    // Update is called once per frame
    void Update()
    {
        //icone.GetComponent<Image>().sprite;
    }
    public void changeIcone(string iconeType)
    {
        Debug.Log(iconeType);
    }
}
