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

        if(isFlipped)
        {
            SetSprite(frontSprite);
            return;
        }

        SetSprite(backSprite);

        Debug.Log(symbolName);
    }
    
    private void SetSprite(Sprite _sprite)
    {
        image.sprite = _sprite;
    }

    public void SetSymbolName(string _symbolName)
    {
        symbolName = _symbolName;
    }

    public void SetFrontSprite(Sprite _frontSprite)
    {
        frontSprite = _frontSprite;
    }
}
