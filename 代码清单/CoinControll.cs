using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControll : MonoBehaviour
{

    public int Hp = 1;
    private Rigidbody2D rBody;
    private Animator ani;
    private bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    

    // 如果有人进了触发区域
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            AudioManager.Instance.PlaySound("coin"); //播放音效
            Destroy(gameObject);  //自身销毁
            
        }
    }
}
