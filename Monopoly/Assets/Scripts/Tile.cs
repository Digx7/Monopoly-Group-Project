using System;
using System.Collections.Generic;
using UnityEngine;

public class Tile: MonoBehaviour
{
    public string name; 
    public int price; 
    public int mortgagePrice; 
    public int unmortgagePrice;
    public bool isMortgaged = false;
    public bool isOwned = false;
    public int ownerID = -1;
    public Sprite frontSprite;
    public Sprite backSprite;

    public void Buy(int buyerID)
    {
        isOwned = true;
        ownerID = buyerID;
    }

    public void Trade(int newOwner, int previousOwner = 0)
    {
        isOwned = true;
        ownerID = newOwner;
    }

    public void Mortgage()
    {
        isMortgaged = true;
    }

    public void UnMortgage()
    {
        isMortgaged = false;
    }

    public virtual int CalculateRent()
    {
        return 0;
    }
}