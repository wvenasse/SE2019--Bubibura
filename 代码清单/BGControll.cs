using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGControll : MonoBehaviour
{
    public float Speed = 0.2f;  //速度
    //地面预设体
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.localPosition;  //得到当前位置
        v.x -= Speed * Time.deltaTime;      //地图左移动
        //判断如果出了屏幕 ，就移动到新位置
        if (v.x < -7.2f)
        {
            v.x += 7.2f * 2; 
            
        }
        transform.localPosition = v;

    }
}
