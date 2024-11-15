using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public static CardGenerator instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] private Card[] cardSymbols;

    public Card GenerateCard()
    {
       return cardSymbols[Random.Range(0, cardSymbols.Length)];
    }
}
