using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text comboText;
    [SerializeField] TMP_Text livesText;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        UpdateScoreText();
        UpdateTotalComboText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = ScoreManager.instance.GetScore().ToString();
    }

    public void UpdateTotalComboText()
    {
        comboText.text = ScoreManager.instance.GetTotalComboCount().ToString();
    }

    public void HideScoreAndComboText()
    {
        scoreText.transform.parent.gameObject.SetActive(false);
        comboText.transform.parent.gameObject.SetActive(false);
    }
}
