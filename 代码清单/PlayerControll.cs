using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    public int Hp = 1;
    public int score = 0;
    public float timer = 60;
    
    public Text scoretext;
    public Text timetext;

    public Button pause;
    public Button contin;
    public Button again;
    public Button stop;
    public Button next;

    public Toggle mute;

    public Slider volume;

    public GameObject winText;
    public GameObject dieText;
    public GameObject timeText;

    public GameObject menu;


    private Rigidbody2D rBody;
    private Animator ani;

    private bool isGround = false;

    private void Awake()
    {
        volume.value = 1;
        menu.SetActive(false);
        Button openbt = pause.GetComponent<Button>();
        openbt.onClick.AddListener(Pause);
        Button conbt = contin.GetComponent<Button>();
        conbt.onClick.AddListener(Contin);
        Button againbt = again.GetComponent<Button>();
        againbt.onClick.AddListener(Again);  
        Button stopbt = stop.GetComponent<Button>();
        stopbt.onClick.AddListener(Stop);
    }

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (mute.isOn==false)
        {
            AudioListener.volume = volume.value;
        }
        if (mute.isOn == true)
        {
            AudioListener.volume = volume.value;
            AudioListener.volume = 0;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timetext.text = "CountDown : "+ timer.ToString("00");
        }
        else GameOver();
        
    }
    //跳跃
    public void Jump()
    {   
        if(isGround == true && Hp>0 )
        {
            //给一个力  方向*数值
            rBody.AddForce(Vector2.up * 400);
            //播放音效
            AudioManager.Instance.PlaySound("button");
        }
    }
    public void Jump1()
    {
        if (isGround == false && Hp > 0)
        {
            //给一个力  方向*数值
            rBody.AddForce(Vector2.up * 200);
            //播放音效
            AudioManager.Instance.PlaySound("button");
        }
    }
    //发生碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果碰到地面
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
            //结束跳跃动画
            ani.SetBool("Jump", false);
        }
    }
    //结束碰撞
    private void OnCollisionExit2D(Collision2D collision)
    {
        //如果是地面,离开地面
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            //开始跳跃动画
            ani.SetBool("Jump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //碰到了路障||timer<=0+ timer.ToString("00")
        if ((collision.tag == "Barrier" && Hp > 0))
        {
            Hp--;
            //timer = 0;
            if (Hp<=0)
            {
                ani.SetBool("Die", true);
                //AudioManager.Instance.PlaySound("");             
                dieText.SetActive(true);
                menu.SetActive(true);
                Button againbt = again.GetComponent<Button>();
                againbt.onClick.AddListener(Again);
                Button stopbt = stop.GetComponent<Button>();
                stopbt.onClick.AddListener(Stop);
                Destroy(rBody);
                
            }
        }
        //碰到了金币
        if (collision.tag == "Coin" )
        {
            score++;
            scoretext.text = "Score: " + score.ToString();
            if (score==100)
            {
                winText.SetActive(true);
                menu.SetActive(true);
                Time.timeScale = 0;
                Button nextbt = next.GetComponent<Button>();
                nextbt.onClick.AddListener(Next);
            }

            Destroy(collision.gameObject);  //自身销毁
        }
        
    }
    //暂停游戏
    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    //继续游戏
    void Contin()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    //重新开始
    void Again()
    {
        //SceneManager.LoadScene(Running);
        Application.LoadLevel("Running");
    }

    //停止游戏
    void Stop()
    {
        Application.LoadLevel("choosing");
    }

    //下一关游戏
    void Next()
    {
        Application.LoadLevel("Running_two");
    }

    void GameOver()
    {
        //time.GetComponent<Text>().text = "Game Over!";
        //ani.SetBool("Die", true);
        Time.timeScale = 0;
        winText.SetActive(true);
        menu.SetActive(true);
        Button nextbt = next.GetComponent<Button>();
        nextbt.onClick.AddListener(Next);
        Destroy(rBody);
    }
}
