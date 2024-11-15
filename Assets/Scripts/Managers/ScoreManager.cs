using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

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

    public void AddScore(bool isCombo)
    {
        if (isCombo)
        {
            currentScore += matchScore * scoreComboMultiplier;

            currComboCount++;
            if (currComboCount > totalComboCount)
            {
                totalComboCount = currComboCount;
            }
            AudioManager.instance.PlaySFX($"Combo{currComboCount}");
            return;
        }

        currComboCount = 0;

        currentScore += matchScore;
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
