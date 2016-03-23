using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour 
{

    private CardData cCardData;

    public CardData cardData { get { return cCardData; } }

    public void Initialize(CardData CardData)
    {
        cCardData = new CardData();
        cCardData = CardData;
    }
}
