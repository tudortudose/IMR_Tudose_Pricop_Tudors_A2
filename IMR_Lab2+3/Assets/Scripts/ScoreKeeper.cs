using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int totalScore;
    public int bestScore;

    [SerializeField]
    private TextMeshProUGUI totalScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMesh textMesh;

    private static readonly string TOTAL_SCORE = "Total Score\n";
    private static readonly string BEST_SCORE = "Best Score\n";

    void Awake()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        totalScore = 0;
        totalScoreText.text = TOTAL_SCORE + totalScore;
        bestScoreText.text = BEST_SCORE + bestScore;
    }

    public void ShowScore(int score)
    {
        textMesh.text = score.ToString();
        UpdateTotalScore(score);
    }


    private void UpdateTotalScore(int score)
    {
        totalScore += score;
        if(totalScore > bestScore)
        {
            bestScore = totalScore;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        totalScoreText.text = TOTAL_SCORE + totalScore;
        bestScoreText.text = BEST_SCORE + bestScore;
    }
}
