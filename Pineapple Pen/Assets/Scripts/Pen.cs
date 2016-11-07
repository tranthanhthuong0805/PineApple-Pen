using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Pen : MonoBehaviour {

    private bool trigger;
    public bool Trigger
    {
        get { return trigger; }
        set { trigger = value; }
    }

    private int penSpeed;

    private float positionYTrigger;
    public float PositionYTrigger
    {
        get { return positionYTrigger; }
        set { positionYTrigger = value; }
    }
    private bool saveY;

    private Animator anim;
    // Use this for initialization
    void Awake()
    {
        
        penSpeed = 40;
        anim = GetComponent<Animator>();
        Shop.pen = PlayerPrefs.GetString("Pen");
        anim.SetTrigger(Shop.pen);
    }

    public void PenMove()
    {
        Vector3 temp = transform.position;              // Lấy vị trí của Pen
        temp.y = temp.y + (penSpeed * Time.deltaTime); // Di chuyển = vị trí cũ + tốc độ * thời gian thực
        transform.position = temp;
    }


    void OnTriggerEnter2D(Collider2D col2)
    {
        if (col2.tag == "Apple")
        {
            trigger = true;
            if (saveY == false)
            {
                positionYTrigger = transform.position.y;
                saveY = true;
            }
        }
    }
}
