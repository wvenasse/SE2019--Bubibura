using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        // 找到该按钮要关闭的Panel对象中的PanelFade脚本
        RankControll _panelfade_script = gameObject.GetComponentInParent<RankControll>();
        // 把脚本中对应关闭状态的_closing设为true
        _panelfade_script._closing = true;
    }
}

