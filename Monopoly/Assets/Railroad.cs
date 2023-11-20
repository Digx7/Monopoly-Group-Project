using System;
using System.Collections;
using UnityEngine;

public class Railroad : Tile
{
    private bool hasCard1 = false;
    private bool hasCard2 = false;
    private bool hasCard3 = false;
    private bool hasCard4 = false;

    public string railroadName { get; set; }

    //UNCOMMENT WHEN MERGED
    //private int RailroadPrice = GetTileCost();

    public void SetCard1(bool card)
    {
        hasCard1 = card;
    }

    public void SetCard2(bool card)
    {
        hasCard2 = card;
    }

    public void SetCard3(bool card)
    {
        hasCard3 = card;
    }

    public void SetCard4(bool card)
    {
        hasCard4 = card;
    }

    public int GetRent()
    {
        int multiplier = 0;
        if (hasCard1)
        {
            multiplier++;
        }
        if (hasCard2)
        {
            multiplier++;
        }
        if (hasCard3)
        {
            multiplier++;
        }
        if (hasCard4)
        {
            multiplier++;
        }
        return 0;
        //RailroadPrice * multiplier;
        //UNCOMMENT THIS WHEN MERGED
    }
}