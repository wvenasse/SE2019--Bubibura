using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankItem : MonoBehaviour {

    [SerializeField] private Text _rank;

    [SerializeField] private Text _name;

    [SerializeField] private Text _score;

    public void SetScore(ScoreData data) {
        _name.text=data.Name;
        _score.text=data.Score.ToString();
    }

    public void SetRank(int rank) {
        _rank.text=rank.ToString();
    }
}
