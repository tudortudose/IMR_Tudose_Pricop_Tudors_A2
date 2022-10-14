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

    private static readonly string TOTAL_SCORE = "Total Score: ";
    private static readonly string Best_SCORE = "Best Score: ";

    void Awake()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        totalScore = 0;
        totalScoreText.text = TOTAL_SCORE + totalScore;
        bestScoreText.text = TOTAL_SCORE + bestScore;
    }

    public void ShowScore(int score)
    {
        textMesh.text = score.ToString();
        UpdateTotalScore(score);
        Invoke("CloseScore", 1f);
    }

    private void CloseScore()
    {
        textMesh.text = "";
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
        bestScoreText.text = TOTAL_SCORE + bestScore;
    }
}
