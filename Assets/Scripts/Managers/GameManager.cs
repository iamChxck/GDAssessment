using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    List<GameCard> clickedCards = new List<GameCard>();

    bool isCombo = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddCardClickedToList(GameCard _clickedCard)
    {
        if (_clickedCard.GetIsFlipped())
        {
            clickedCards.Add(_clickedCard);
        }

        if (clickedCards.Count == 2)
        {
            CheckIfCardsMatched();
        }

        if (clickedCards.Count > 2)
        {
            clickedCards.Clear();
            clickedCards.Add(_clickedCard);
        }
    }

    public void RemoveCardClickedFromList(GameCard _clickedCard)
    {
        clickedCards.Remove(_clickedCard);
    }

    void CheckIfCardsMatched()
    {
        if (clickedCards[0].GetSymbolName() == clickedCards[1].GetSymbolName())
        {
            foreach (GameCard card in clickedCards)
            {
                card.SetIsMatchedToTrue();
                card.DisableCard();
            }
            ScoreManager.instance.AddScore(isCombo);
            isCombo = true;
            return;
        }

        isCombo = false;
        StartCoroutine(UndoCardFlip());
    }

    IEnumerator UndoCardFlip()
    {
        List<GameCard> tempCards = clickedCards.ToList();

        yield return new WaitForSeconds(1f);

        foreach (GameCard card in tempCards)
        {
            card.FlipCard();
        }
    }
}
