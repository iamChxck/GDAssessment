using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    int matchScore = 5;
    [SerializeField]
    int scoreComboMultiplier = 2;

    private void Awake()
    {
        instance = this;
    }

    int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(bool isCombo)
    {
        if (isCombo)
        {
            currentScore += matchScore * scoreComboMultiplier;
            UpdateScoreText();
            return;
        }

        currentScore += matchScore;
        UpdateScoreText();
    }
}
