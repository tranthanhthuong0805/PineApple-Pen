using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public static string pen;                              //Loại pen
    private GameObject[] item;
    private int[] firstValue;

    void Start()
    {
        firstValue = new int[item.Length];
        for (int i = 0; i < item.Length; i++)
        {
            firstValue[i] = item[i].GetComponent<ItemButton>().NoLockedPen;
            if (item[i].GetComponent<ItemButton>().NoLockedPen == 1)
                item[i].GetComponent<Image>().sprite = item[i].GetComponent<ItemButton>().notSelected;
            else if (item[i].GetComponent<ItemButton>().NoLockedPen == 2)
            {
                item[i].GetComponent<Image>().sprite = item[i].GetComponent<ItemButton>().selected;
                pen = item[i].GetComponent<ItemButton>().NamePen;
                PlayerPrefs.SetString("Pen", pen);
            }
        }
    }

	// Use this for initialization
	void Awake () {
        pen = PlayerPrefs.GetString("Pen");
        item = GameObject.FindGameObjectsWithTag("Item");
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < item.Length; i++)
        {
            if (firstValue[i] != item[i].GetComponent<ItemButton>().NoLockedPen)
            {
                for (int j = 0; j < item.Length; j++)
                {
                    if(j != i)
                    {
                        if(item[j].GetComponent<ItemButton>().NoLockedPen != 0)
                        {
                            firstValue[j] = 1;
                            PlayerPrefs.SetInt(item[j].name, 1);
                            item[j].GetComponent<ItemButton>().NoLockedPen = 1;
                            PlayerPrefs.SetInt(item[j].name, 1);
                            item[j].GetComponent<Image>().sprite = item[j].GetComponent<ItemButton>().notSelected;
                        }
                    }
                }

                if (item[i].GetComponent<ItemButton>().NoLockedPen == 2)
                {
                    item[i].GetComponent<Image>().sprite = item[i].GetComponent<ItemButton>().selected;
                    PlayerPrefs.SetInt(item[i].name, 2);
                    firstValue[i] = 2;
                    pen = item[i].GetComponent<ItemButton>().NamePen;
                    PlayerPrefs.SetString("Pen", pen);
                }
                if (item[i].GetComponent<ItemButton>().NoLockedPen == 3)
                {
                    item[i].GetComponent<ItemButton>().NoLockedPen = 2;
                    item[i].GetComponent<Image>().sprite = item[i].GetComponent<ItemButton>().selected;
                    PlayerPrefs.SetInt(item[i].name, 2);
                    StartCoroutine(LoadGamePlay(0.1f));
                    UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
                }
                
                break;
            }
        }
	}

    IEnumerator LoadGamePlay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
