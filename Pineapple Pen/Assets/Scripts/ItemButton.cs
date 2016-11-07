using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

    public Sprite notSelected, selected;
    private string namePen;
    public string NamePen
    {
        get { return namePen; }
        set { namePen = value; }
    }

    private int noLockedPen;
    public int NoLockedPen
    {
        get { return noLockedPen; }
        set { noLockedPen = value; }
    }
    
    public void NoLocked()
    {
        if (noLockedPen != 0)
        {
            noLockedPen++;
            
        }

        if (noLockedPen == 0)
        {
            if (Coin.coin >= 200)
            {
                if (this.name != "Button1")
                {
                    Destroy(transform.GetChild(1).gameObject);
                }
                transform.GetChild(0).GetComponent<Image>().enabled = true;
                noLockedPen = 2;
                Coin.coin -= 200;
            }
        }
    }

	// Use this for initialization
	void Awake () {
        namePen = transform.GetChild(0).name;
        print(PlayerPrefs.GetInt(this.name));
        noLockedPen = PlayerPrefs.GetInt(this.name);
        if (this.name == "Button1" && noLockedPen == 0)
        {
            noLockedPen = 2;
            PlayerPrefs.SetInt(this.name, noLockedPen);
        }

        if (noLockedPen == 0)
        {
            transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        else
        {
            if (this.name != "Button1")
            {
                Destroy(transform.GetChild(1).gameObject);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
