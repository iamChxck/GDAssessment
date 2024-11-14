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
    TMP_Text comboText;

    [SerializeField]
    int matchScore = 5;
    [SerializeField]
    int scoreComboMultiplier = 2;

    int currComboCount = 0;
    int totalComboCount = 0;

    private void Awake()
    {
        instance = this;
    }

    int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
        UpdateTotalComboText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void UpdateTotalComboText()
    {
        comboText.text = totalComboCount.ToString();
    }

    public void AddScore(bool isCombo)
    {
        if (isCombo)
        {
            currentScore += matchScore * scoreComboMultiplier;
            UpdateScoreText();

            currComboCount++;
            if (currComboCount > totalComboCount)
            {
                totalComboCount = currComboCount;
            }
            AudioManager.instance.PlaySFX($"Combo{currComboCount}");
            UpdateTotalComboText();
            return;
        }

        currComboCount = 0;

        currentScore += matchScore;
        UpdateScoreText();
    }

    public void HideScoreAndComboText()
    {
        scoreText.transform.parent.gameObject.SetActive(false);
        comboText.transform.parent.gameObject.SetActive(false);
    }

    public int GetScore()
    {
        return currentScore;
    }

    public int GetTotalComboCount()
    {
        return totalComboCount;
    }
}
