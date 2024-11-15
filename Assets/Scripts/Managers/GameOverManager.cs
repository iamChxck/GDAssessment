using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TMP_Text finalScoreText, longestComboStreak;

    [SerializeField]
    GameObject backButton;

    private void OnEnable()
    {
        gameOverPanel.SetActive(true);
        backButton.SetActive(false);
        GameUIManager.instance.HideScoreAndComboText();

        finalScoreText.text = ScoreManager.instance.GetScore().ToString();
        longestComboStreak.text = ScoreManager.instance.GetTotalComboCount().ToString();
    }

    public void LoadMainMenu()
    {
        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySFX("ButtonClick");
        StartCoroutine(TransitionPanel.instance.StartTransitionPanelAnimation("MainMenu"));
    }
}
