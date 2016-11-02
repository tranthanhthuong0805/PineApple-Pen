using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    public static int coin;
    Text text;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
        coin = PlayerPrefs.GetInt("Coin");
        text = GetComponent<Text>();
        coin = 10;
    }

    public static Coin Instance { get; private set; }

    public void SetCoin(int value)
    {
        coin += value;
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", coin);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coin.ToString();
    }
}
