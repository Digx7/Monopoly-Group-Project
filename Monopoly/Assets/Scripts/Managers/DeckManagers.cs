using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManagers : MonoBehaviour
{
    public Deck warningDeck;
    public Deck errorDeck;

    public Card DrawCard(WarningOrError cardType)
    {
        if(cardType == WarningOrError.Warning)
        {
            return warningDeck.DrawCard();
        }
        else
        {
            return errorDeck.DrawCard();
        }
    }
}
