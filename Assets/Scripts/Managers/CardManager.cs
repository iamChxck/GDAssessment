using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour, IDataPersistence
{
    public static CardManager instance;

    public GameObject[] cards;

    int possiblePermutations = 0;

    [SerializeField]
    GameObject panelCover;

    [SerializeField]
    List<Card> cardSymbols;

    private void Awake()
    {
        instance = this;
        cards = GameObject.FindGameObjectsWithTag("Card");
    }

    public void LoadData(GameData gameData)
    {
        for (int i = 0; i < gameData.idList.Count; i++)
        {
            for (int j = 0; j < cards.Length; j++)
            {
                Debug.Log(cards.Length);
                gameData.gameCardsSymbolName.TryGetValue(gameData.idList[i], out cards[j].GetComponent<GameCard>().symbolName);
                gameData.gameCardsMatched.TryGetValue(gameData.idList[i], out cards[j].GetComponent<GameCard>().isMatched);

                if (cards[i].GetComponent<GameCard>().isMatched)
                {
                    cards[i].GetComponent<GameCard>().SetIsFlipped(cards[i].GetComponent<GameCard>().isMatched);
                    cards[i].GetComponent<GameCard>().ShowCard();
                    cards[i].GetComponent<GameCard>().DisableCard();
                }
            }

        }
    }

    public void SaveData(ref GameData gameData)
    {
        foreach (GameObject card in cards)
        {
            if (gameData.gameCardsMatched.ContainsKey(card.GetComponent<GameCard>().id))
            {
                gameData.gameCardsMatched.Remove(card.GetComponent<GameCard>().id);
                gameData.gameCardsSymbolName.Remove(card.GetComponent<GameCard>().symbolName);
                gameData.idList.Remove(card.GetComponent<GameCard>().id);
            }
            gameData.gameCardsMatched.Add(card.GetComponent<GameCard>().id, card.GetComponent<GameCard>().isMatched);
            gameData.gameCardsSymbolName.Add(card.GetComponent<GameCard>().id, card.GetComponent<GameCard>().symbolName);
            gameData.idList.Add(card.GetComponent<GameCard>().id);
        }
    }

    void Start()
    {
        if (DataPersistenceManager.instance.gameData.CheckIsEmpty())
        {
            GeneratePossiblePermutations();
            AssignCardValues();
        }

        StartCoroutine(ShowCardsAtTheStartOfGame());
    }

    void GeneratePossiblePermutations()
    {
        possiblePermutations = cards.Length / 2;
        for (int i = 0; i < possiblePermutations; i++)
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
                gameCard.id = System.Guid.NewGuid().ToString();
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

    public IEnumerator ShowCardsAtTheStartOfGame()
    {
        foreach (GameObject card in cards)
        {
            card.GetComponent<GameCard>().ShowCard();
        }

        yield return new WaitForSeconds(2f);

        foreach (GameObject card in cards)
        {
            card.GetComponent<GameCard>().HideCard();
        }

        panelCover.SetActive(false);
    }
}
