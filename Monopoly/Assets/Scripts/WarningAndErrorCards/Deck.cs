using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;

    // Recompile

    public Card DrawCard()
    {
        int r = Random.Range(0, cards.Count);

        return cards[r];
    }
}
