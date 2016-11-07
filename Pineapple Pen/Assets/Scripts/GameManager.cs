using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Fruit[] fruitsSpawn;         //Mảng các loại fruit có thể sinh
    private int totalFruit;             //Tổng số các loại fruit trong mảng fruitsSpawn

    private Fruit[] fruits;             //Mảng fruits
    private int fruitCount;             //Số phần tử trong mảng fruits

    public Pen[] pensSpawn;             //Mảng các loại pen có thể sinh
    private int totalPen;               //Tổng số các loại pen trong mảng pensSpawn

    private Pen[] pens;                 //Mảng pens
    private int penCount;               //Số phần tử trong mảng pens
    
    private bool penLive;               //Sử dụng cho PlayButton (Click button thì penLive = true)

    private int[] doubleKill;           //Lưu giá trị random để show emotion (0: không show, 1: show)
    private int[] species;              //Lưu loại fruit (apple, pineapple, swag)
        
    public Emotion[] emotions;          //Mảng các loại emotion
    private int totalEmotion;           //Tổng số các loại emotion trong mảng emotions

	// Use this for initialization
	void Start ()
	{
        fruits = new Fruit[100];
        pens = new Pen[100];
        doubleKill = new int[100];
        species = new int[100];

	    fruitCount = 0;
        penCount = 0;
	    
        totalFruit = fruitsSpawn.Length;
        totalPen = pensSpawn.Length;
        totalEmotion = emotions.Length;
	    
        SpawnFruit();                       //Tạo fruit
        SpawnPen();                         //Tạo pen
	}

    public void PenButton()
    {   
        penLive = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (pens[penCount] != null)
        {
            //penLive = true (click)
            if (penLive)
            {
                pens[penCount].PenMove();           //Hàm di chuyển pen
            }

            //Khi không va chạm
            if (pens[penCount].Trigger == false)   
            {
                //Pen di chuyển ra khỏi camera
                if (pens[penCount].transform.position.y >= 11.5f)
                {
                    Miss(pens[penCount], fruits[fruitCount]);   //Xử lý khi miss
                    
                }
            }
            //Khi va chạm
            else
            {
                //Vị trí Pen >= vị trí va chạm
                if (pens[penCount].transform.position.y >= pens[penCount].PositionYTrigger)
                {
                    Trigger(pens[penCount], fruits[fruitCount]);    //Xử lý va chạm
                }
            }
        }

        
	}

    //Xử lý pen và fruit va chạm
    private void Trigger(Pen pen, Fruit fruit)
    {
        Dead(pen, fruit);                   //Xử lý pen và fruit
        Score.Instance.SetScore(1);         //Xử lý điểm số
        Sound.Instance.SoundStop();         //Tắt audio
        Sound.Instance.SoundTrigger();      //Phát âm thanh va chạm
        Score.Instance.PlaySoundPpap();
        SpawnImage();                       //Xử lý show ảnh guy_emotion

        Spawn();                            //Xử lý sinh
        penLive = false;                    //Ngừng di chuyển pen
    }

    //Xử lý pen và fruit không va chạm
    private void Miss(Pen pen, Fruit fruit)
    {
        fruit.GetComponent<Animator>().SetTrigger("Miss");  //Set animation Miss
        ShowButton();                                       //Hiện các button
        ShowScore();                                        //Hiện điểm
        Destroy(pen.gameObject);                            //Xóa pen
        Score.Instance.StopSoundPpap();
        Sound.Instance.SoundStop();                         //Tắt audio
        Sound.Instance.SoundGameOver();                     //Phát âm thanh gameover


        penLive = false;                                    //Ngừng di chuyển pen
    }

    //Tạo fruit
    private void SpawnFruit()
    {
        //Fruit đầu tiên random apple hoặc pineapple
        if (fruitCount == 0)
        {
            int temp = Random.Range(0, 2);
            fruits[fruitCount] = Instantiate(fruitsSpawn[temp]);    //Tạo fruit
            species[fruitCount] = temp;                             //Loại fruit

            doubleKill[fruitCount] = Random.Range(0, 2);            //Random show emotion
        }
        //Các fruit sau random thêm swagapple, swagpineapple
        else
        {
            int temp = Random.Range(0, 4);  //Tỉ lệ xuất hiện
            if (temp == 0)
            {
                fruits[fruitCount] = Instantiate(fruitsSpawn[Random.Range(2, totalFruit)]); //0: random swagapple hoặc swagpineapple
                doubleKill[fruitCount] = 0;
                species[fruitCount] = 2;
            }
            else
            {
                int temp1 = Random.Range(0, 2);
                fruits[fruitCount] = Instantiate(fruitsSpawn[temp1]);          //1, 2, 3: random apple hoặc pineapple
                species[fruitCount] = temp1;
                doubleKill[fruitCount] = Random.Range(0, 2);
            }
        }
        
        //Khởi tạo vị trí và di chuyển fruit
        if (fruits[fruitCount] != null)
        {
            var trans = fruits[fruitCount].transform;
            if (fruitCount == 0)
                trans.localPosition = new Vector3(0, 2.63f, 0);
            else
            {
                int xRandom = Random.Range(1, 3);
                if (xRandom == 1)
                    xRandom = 4;
                else
                    xRandom = -4;
                trans.localPosition = new Vector3(xRandom, Random.Range(0f, 3.63f), 0);
                fruits[fruitCount].FruitMove();
            }

            fruits[fruitCount].name = String.Format("Fruit_{0}", fruitCount + 1);
        }
    }

    //Tạo pen
    private void SpawnPen()
    {
        pens[penCount] = Instantiate(pensSpawn[0]);     //Đang sử dụng loại pen đầu

        //Khởi tạo vị trí pen
        if (pens[penCount] != null)
        {
            var trans = pens[penCount].transform;
            trans.localPosition = new Vector3(0, -5.8f, 0);

            pens[penCount].name = String.Format("Pen_{0}", penCount + 1);
        }
    }

    //Gộp pen vào fruit rồi scal, rotate và move
    private void Dead(Pen pen, Fruit fruit)
    {
        fruit.GetComponent<Animator>().SetTrigger("Dead");
        pen.transform.SetParent(fruit.transform);
        var trans = fruit.transform;
        trans.DORotate(new Vector3(0, 0, -36000), 120);
        trans.DOScale(0.2f, 5);

        Vector3[] waypoints = new[] {
            new Vector3(-0.75f, 4, 0),
		    new Vector3(-1.5f, 7, 0),
            new Vector3(-2.25f, 4, 0),
		    new Vector3(-3, trans.position.y, 0),
		    new Vector3(-3, -600, 0)
        };

        trans.DOPath(waypoints, 70, PathType.Linear);
    }

    //Tạo pen và fruit
    private void Spawn()
    {
        penCount++;
        SpawnPen();
        fruitCount++;
        SpawnFruit();
    }

    //Show các button khi gameover
    private void ShowButton()
    {
        //Tìm Transform của các button
        Transform restart = GameObject.Find("RestartButton").GetComponent<Transform>();
        Transform leaderboards = GameObject.Find("LeaderboardsButton").GetComponent<Transform>();
        Transform share = GameObject.Find("ShareButton").GetComponent<Transform>();
        Transform videoAd = GameObject.Find("VideoAdButton").GetComponent<Transform>();

        //Di chuyển các button
        restart.DOMoveY(-5.8f, 0.5f);
        leaderboards.DOMoveY(-5.8f, 0.5f);
        share.DOMoveY(-5.8f, 0.5f);
        videoAd.DOMoveY(-3f, 0.2f);
    }

    //Show score và lưu highscore
    private void ShowScore()
    {
        Transform star = GameObject.Find("HighScoreStar").GetComponent<Transform>();
        if (Score.score <= Score.highScore)
        {
            GameObject text = GameObject.Find("HighScoreText");
            text.GetComponent<Text>().text = Score.highScore.ToString();
            star.DOMoveY(4.3f, 0.5f);
        }
        else
        {
            star.DOMoveY(6.5f, 0.5f);
        }

        Score.Instance.SaveHighScore();
    }

    //Xử lý trường hợp đặc biệt (2 pen và 2 fruit) và tạo emotion
    private void SpawnImage()
    {
        //Khi fruit vị trí thứ 3 và 2 fruit trước có show emotion và 2 fruit trước phải khác loại (1 apple, 1 pineapple)
        if (fruitCount >= 2 && doubleKill[fruitCount - 2] == 1 && doubleKill[fruitCount - 1] == 1 && species[fruitCount - 2] != species[fruitCount - 1])
            Special();
        //Ngược lại nếu có emotion
        else if(doubleKill[fruitCount] == 1)
        {
            //Nếu là loại 0 (Apple)
            if(species[fruitCount] == 0)
            {
                SpawnImageApple();          //Tạo emotion apple
            }
            //Ngược lại nếu loại 1 (PineApple)
            else if (species[fruitCount] == 1)
            {
                SpawnImagePineApple();      //Tạo emotion pineapple
            }
            //Ngược lại (loại swag)
            else
            {

            }
        }
    }

    //Hàm xử lý trường hợp đặc biệt
    private void Special()
    {

    }

    //Hàm tạo emotion apple
    private void SpawnImageApple()
    {
        Instantiate(emotions[0]);
    }

    //Hàm tạo emotion pineapple
    private void SpawnImagePineApple()
    {
        Instantiate(emotions[1]);
    }
}
