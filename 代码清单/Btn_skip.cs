using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Btn_skip : MonoBehaviour
{
    // Use this for initialization  


    public void Skip()
    {


        //进入Running场景
        Application.LoadLevel("Running");

    }
}


