using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI nowScoreUI;
    public TextMeshProUGUI bestScoreUI;

    public int nowScore;
    public int bestScore;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestscore");
        bestScoreUI.text = "Best Score : " + bestScore;

    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("bestscore", 0);

        bestScore = 0;
        bestScoreUI.text = "Best Score : " + bestScore;
        nowScore = 0;

        nowScoreUI.text = "Now Score : 0";
    }

}
