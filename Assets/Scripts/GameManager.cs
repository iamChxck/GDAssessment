using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    List<GameCard> clickedCards = new List<GameCard>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddCardClickedToList(GameCard clickedCard)
    {
        if (clickedCard.GetIsFlipped())
        {
            clickedCards.Add(clickedCard);
        }

        if (clickedCards.Count == 2)
        {
            CheckIfCardsMatched();
        }

        if (clickedCards.Count > 2)
        {
            clickedCards.Clear();
            clickedCards.Add(clickedCard);
        }
    }

    public void RemoveCardClickedFromList(GameCard clickedCard)
    {
        clickedCards.Remove(clickedCard);
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
            return;
        }

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
