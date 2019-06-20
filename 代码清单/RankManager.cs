using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankManager : MonoBehaviour {

	//public static RankManager Instance; //单例

	public Transform RankGroup; //排行榜列表容器

	public GameObject RankPrefab; //排行榜Prefab

    public GameObject RankDialog; //排行榜面板

    public static RankModel RankModel; //保存的排行榜数据模型

    public string Key = "Data1";

	// Use this for initialization
	void Awake() {
		//Instance=this;
		RankModel=JsonUtility.FromJson<RankModel>(PlayerPrefs.GetString(Key,JsonUtility.ToJson(new RankModel()))); //获取排行榜数据
		print("排行榜长度"+RankModel.Ranks.Count);
        //DontDestroyOnLoad(this);
	}

	/// <summary>
	/// 初始化排行榜列表
	/// </summary>
	public void Init()
	{

		int i = 1;
		foreach(RectTransform t in RankGroup) {
			Destroy(t.gameObject);
		}
		RankModel.Ranks.Sort();
		print("初始化"+RankModel.Ranks.Count);
		foreach(var r in RankModel.Ranks) {
			var go = Instantiate(RankPrefab,RankGroup,false).GetComponent<RankItem>();
            go.SetRank(i);
			go.SetScore(new ScoreData(){Name = r.Name,Score = r.Score});
			i++;
		}
	}

	public void Add(string nickname,int score) {
		//添加排行榜数据
		RankModel.Ranks.Add(new RankItemModel() {
			Name=nickname,
			Score=score
		});

		//保存数据
		PlayerPrefs.SetString(Key,JsonUtility.ToJson(RankModel));
		PlayerPrefs.Save();
		print("保存成功"+RankModel.Ranks.Count+JsonUtility.ToJson(RankModel));
		print("保存数据长度为" + JsonUtility.FromJson<RankModel>(PlayerPrefs.GetString("Data", JsonUtility.ToJson(new RankModel())))
			      .Ranks.Count);
	}

	/// <summary>
	/// 打开排行榜输入窗口
	/// </summary>
	public void OpenDialog() {
	    RankDialog.gameObject.SetActive(true);
        //RankDialog.Instance.SetDistance(MoveController.mLength);
        //RankDialog.Instance.Show();
    }


}
