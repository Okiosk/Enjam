using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ui_le_script : MonoBehaviour
{
    public Sprite icon1;
    public Sprite icon2;
    public Sprite icon3;
    public Sprite icon4;
    public GameObject icon;
    public void changeIcon(string name)
    {
        switch (name)
        {
            case "orange":
                icon.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                icon.GetComponent<Image>().sprite = icon1;
                break;
            case "green":
                icon.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                icon.GetComponent<Image>().sprite = icon2;
                break;
            case "blue":
                icon.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                icon.GetComponent<Image>().sprite = icon3;
                break;
            case "pink":
                icon.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                icon.GetComponent<Image>().sprite = icon4;
                break;
            case "none":
                icon.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                break;
        }
    }
}
