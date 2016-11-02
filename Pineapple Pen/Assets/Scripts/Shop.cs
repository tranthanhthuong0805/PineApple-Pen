using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public static int pen;                              //Loại pen
    private GameObject penButton, apocalipseButton;
    public Sprite selected, notSelected;

    public void PenButton()
    {
        pen = 1;
        PlayerPrefs.SetInt("Pen", pen);
    }

    public void ApocalipseButton()
    {
        pen = 2;
        PlayerPrefs.SetInt("Pen", pen);
    }

	// Use this for initialization
	void Awake () {
        pen = PlayerPrefs.GetInt("Pen");
        penButton = GameObject.Find("Button1");

        apocalipseButton = GameObject.Find("Button2");
	}
	
	// Update is called once per frame
	void Update () {

        switch(pen)
        {
            case 1:
                {
                    apocalipseButton.GetComponent<Image>().sprite = notSelected;
                    penButton.GetComponent<Image>().sprite = selected;
                    break;
                }
            case 2:
                {
                    penButton.GetComponent<Image>().sprite = notSelected;
                    apocalipseButton.GetComponent<Image>().sprite = selected;
                    break;
                }
        }
	}
}
