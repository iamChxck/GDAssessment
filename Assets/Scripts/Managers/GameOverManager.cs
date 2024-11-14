using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TMP_Text finalScoreText, longestComboStreak;

    private void OnEnable()
    {
        gameOverPanel.SetActive(true);
        ScoreManager.instance.HideScoreAndComboText();

        finalScoreText.text = ScoreManager.instance.GetScore().ToString();
        longestComboStreak.text = ScoreManager.instance.GetTotalComboCount().ToString();
    }

    public void LoadMainMenu()
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySFX("ButtonClick");
        SceneManager.LoadScene("MainMenu");
    }
}
