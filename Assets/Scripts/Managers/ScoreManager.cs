using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IDataPersistence
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
    int longestComboStreak = 0;
    
    int currentScore = 0;

    private void Awake()
    {
        instance = this;
    }

    public void LoadData(GameData gameData)
    {
        this.currentScore = gameData.score;
        this.longestComboStreak = gameData.longestComboStreak;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.score = this.currentScore;
        gameData.longestComboStreak = this.longestComboStreak;
    }

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
        comboText.text = longestComboStreak.ToString();
    }

    public void AddScore(bool isCombo)
    {
        if (isCombo)
        {
            currentScore += matchScore * scoreComboMultiplier;
            UpdateScoreText();

            currComboCount++;
            if (currComboCount > longestComboStreak)
            {
                longestComboStreak = currComboCount;
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

    public int GetLongestComboStreak()
    {
        return longestComboStreak;
    }
}
