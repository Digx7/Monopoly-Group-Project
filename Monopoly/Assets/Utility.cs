using System;
using System.Collections.Generic;
using UnityEngine;

public class Utility : Tile
{

    private bool hasCard1 = false;
    private bool hasCard2 = false;
    //UNCOMMENT WHEN MERGED
    //private int UtilityCost = GetTileCost();

    public string utilityName { get; set; }

    public void SetCard1(bool card)
    {
        hasCard1 = card;
    }

    public void SetCard2(bool card)
    {
        hasCard1 = card;
    }

    //UNCOMMENT THIS WHEN THIS IS MERGED
    int CheckCardPossession()
    {
        /* DiceRoll dice = new DiceRoll();
         if (hasCard1 && hasCard2) //if player has both cards
         {
             return dice * 10; //roll dice times 10
         }
         else if (hasCard1 || hasCard2) // checks to see if player has at least one card
         {
             return dice * 4; //roll dice times 4
         }
         */
        return 0;
    }
    public int GetUtilityCost()
    {
        return GetTileCost();
    }
}