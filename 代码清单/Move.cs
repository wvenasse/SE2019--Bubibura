using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private Rigidbody2D rig;   //刚体

    private float jumpForce;  //跳跃的力

    private float horizontal;  //水平偏移量

    private float moveSpeed; //水平移动速度绝对值

    private float move; //水平移动速度（左 或 右）

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();   //获取主角刚体组件

        jumpForce = 300f;   //跳跃力的大小

        moveSpeed = 5.5f;    //水平方向移动速度大小

    }

    void Update()
    {   //上下左右移动
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(Vector3.up * 5 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(Vector3.down * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }

    

            if (Input.GetKeyDown(KeyCode.Space))
        {    //如果按下空格 

            rig.AddForce(new Vector2(0, jumpForce));   //给刚体一个向上的力

            horizontal = Input.GetAxis("Horizontal");   //水平方向按键偏移量

            move = horizontal * moveSpeed;   //刚体具体速度

            rig.velocity = new Vector2(move, rig.velocity.y);

        }

    }

}