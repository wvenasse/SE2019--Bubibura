using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankDialog : MonoBehaviour {

	public static RankDialog Instance;

	//public Text Score; //距离文本

	public InputField InputField;

	private int _lastScore;

    public PlayerControll player;

    public RankManager rank;

	// Use this for initialization
	void Awake() {
		Instance=this;
		//gameObject.SetActive(false);
	}

	/// <summary>
	/// 设置距离文本
	/// </summary>
	/// <param name="score"></param>
	public void SetScore(int score) {
		_lastScore=score;
		//Score.text="分数"+score.ToString();
	}

	/// <summary>
	/// 提交分数
	/// </summary>
	public void SubmitScore() {
	    rank.Add(InputField.text,player.score);
		//SceneManager.LoadScene("start");
	}

	/// <summary>
	/// 显示窗口
	/// </summary>
	public void Show()
	{
		gameObject.SetActive(true);
	}
}
