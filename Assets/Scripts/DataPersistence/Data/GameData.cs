using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public int longestComboStreak;
    public List<string> idList;
    public SerializableDictionary<string, bool> gameCardsMatched;
    public SerializableDictionary<string, string> gameCardsSymbolName;

    public GameData()
    {
        this.score = 0;
        this.longestComboStreak = 0;
        this.idList = new List<string>();
        this.gameCardsMatched = new SerializableDictionary<string, bool>();
        this.gameCardsSymbolName = new SerializableDictionary<string, string>();
    }

    public bool CheckIsEmpty()
    {
        return (this.score == 0 && this.longestComboStreak == 0 && this.idList.Count == 0 && this.gameCardsMatched.Count == 0 && this.gameCardsSymbolName.Count == 0);
    }
}
