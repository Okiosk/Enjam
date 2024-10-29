using UnityEngine;
using UnityEngine.UI;

public class ui_le_script : MonoBehaviour
{
    public Sprite icone1;
    public Sprite icone2;
    public Sprite icone3;
    public Sprite icone4;
    public GameObject icone;
    public void changeIcone(string name)
    {
        if (name == "orange")
        {
            icone.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            icone.GetComponent<Image>().sprite = icone1;
        }
        if (name == "vert")
        {
            icone.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            icone.GetComponent<Image>().sprite = icone2;
        }
        if (name == "bleu")
        {
            icone.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            icone.GetComponent<Image>().sprite = icone3;
        }
        if (name == "rose")
        {
            icone.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            icone.GetComponent<Image>().sprite = icone4;
        }
        if (name == "none")
        {
            icone.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
    }
}
