using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCard : MonoBehaviour
{
    public Sprite backSprite;

    string symbolName;
    Sprite frontSprite;
    bool isFlipped = false;
    bool isMatched = false;

    Image image;

    Button cardButton;

    private void Start()
    {
        image = GetComponent<Image>();
        cardButton = GetComponent<Button>();
        cardButton.onClick.AddListener(FlipCard);
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;

        AudioManager.instance.PlaySFX("CardFlip");

        if (isFlipped)
        {
            ShowCard();
            GameManager.instance.AddCardClickedToList(this);
            return;
        }

        HideCard();
        GameManager.instance.RemoveCardClickedFromList(this);
    }

    public void ShowCard()
    {
        SetSprite(frontSprite);
    }

    public void HideCard()
    {
        SetSprite(backSprite);
    }


    private void SetSprite(Sprite _sprite)
    {
        image.sprite = _sprite;
    }

    public void SetSymbolName(string _symbolName)
    {
        symbolName = _symbolName;
    }

    public string GetSymbolName()
    {
        return symbolName;
    }

    public void SetFrontSprite(Sprite _frontSprite)
    {
        frontSprite = _frontSprite;
    }

    public void SetIsMatchedToTrue()
    {
        isMatched = true;
    }

    public bool GetIsMatched()
    {
        return isMatched;
    }

    public bool GetIsFlipped()
    {
        return isFlipped;
    }

    public void DisableCard()
    {
        cardButton.interactable = false;
    }
}
