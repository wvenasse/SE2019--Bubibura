using UnityEngine;
using System.Collections;

public class RankControll : MonoBehaviour
{
    // 表示Panel正在打开
    public bool _opening;
    // 表示Panel正在关闭
    public bool _closing;

    void Start()
    {
        // 初始时_opening设为true，实现打开时淡入效果
        _opening = true;
        _closing = false;

        // alpha设为0，为全透明
        gameObject.transform.GetComponent<UIPanel>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 处于打开状态，alpha随时间增加
        if (_opening == true)
        {
            // 找到Panel的alpha的值，随时间增加，实现淡入效果
            gameObject.transform.GetComponent<UIPanel>().alpha += Time.deltaTime * 4f;

            // 当alpha>=1时，打开状态结束，_opening设置false
            if (gameObject.transform.GetComponent<UIPanel>().alpha >= 1)
                _opening = false;
        }

        if (_closing == true)
        {
            // 处于关闭状态，alpha随时间减少
            gameObject.transform.GetComponent<UIPanel>().alpha -= Time.deltaTime * 4f;

            // alpha小于0，关闭状态结束，_closing设为false，并且在UI Root下删除该Panel
            if (gameObject.transform.GetComponent<UIPanel>().alpha <= 0)
            {
                _closing = false;
                NGUITools.Destroy(gameObject);
            }
        }
    }
}