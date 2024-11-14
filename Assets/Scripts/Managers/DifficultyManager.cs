using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    [SerializeField]
    Button easyButton;
    [SerializeField]
    Button normalButton;
    [SerializeField]
    Button hardutton;

    public enum difficulty
    {
        EasyGame,
        NormalGame,
        HardGame
    }

    public difficulty difficultySelected;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        difficultySelected = difficulty.NormalGame;
        normalButton.Select();

        easyButton.onClick.AddListener(ChangeDifficultyToEasy);
        normalButton.onClick.AddListener(ChangeDifficultyToNormal);
        hardutton.onClick.AddListener(ChangeDifficultyToHard);
    }

    void ChangeDifficultyToEasy()
    {
        difficultySelected = difficulty.EasyGame;
    }

    void ChangeDifficultyToNormal()
    {
        difficultySelected = difficulty.NormalGame;
    }

    void ChangeDifficultyToHard()
    {
        difficultySelected = difficulty.HardGame;
    }
}
