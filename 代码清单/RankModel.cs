using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 数据模型
/// </summary>
[Serializable]
public class RankModel {

	public List<RankItemModel> Ranks = new List<RankItemModel>(); //排行榜列表

}

[Serializable]
public struct RankItemModel : IComparable<RankItemModel> {
	//public int No; //排名

	public string Name; //名字

	public int Score; //分数

	/// <summary>
	/// 分数对比接口
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public int CompareTo(RankItemModel other) {
		return other.Score-Score;
	}

}