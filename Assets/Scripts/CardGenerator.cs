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

    [SerializeField]
    private Card[] card;

    public Card GenerateCard()
    {
       return card[Random.Range(0, card.Length)];
    }
}
