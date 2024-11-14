using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    GameObject[] cards;

    int possiblePermutations = 0;

    [SerializeField]
    List<Card> cardSymbols;

    void Start()
    {
        cards = GameObject.FindGameObjectsWithTag("Card");
        GeneratePossiblePermutations();
        AssignCardValues();
    }

    void GeneratePossiblePermutations()
    {
        possiblePermutations = cards.Length / 2;
        for(int i = 0; i < possiblePermutations; i++)
        {
            cardSymbols.Add(CardGenerator.instance.GenerateCard());
        }
    }

    void AssignCardValues()
    {
        // Duplicate the card symbols to create pairs
        List<Card> cardPairs = new List<Card>(cardSymbols);
        cardPairs.AddRange(cardSymbols);

        ShuffleCards(cardPairs);

        for (int i = 0; i < cards.Length; i++)
        {
            GameCard gameCard = cards[i].GetComponent<GameCard>();
            if (gameCard != null)
            {
                Card cardData = cardPairs[i];
                gameCard.SetSymbolName(cardData.symbol);
                gameCard.SetFrontSprite(cardData.symbolSprite);
            }
        }
    }

    void ShuffleCards<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}