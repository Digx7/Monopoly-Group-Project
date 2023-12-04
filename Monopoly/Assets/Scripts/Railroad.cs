using System;
using System.Collections;

public class Railroad : Tile
{
    private int railroadRent = 25;

    // public Railroad(string name, int price, int mortgagePrice, int unmortgagePrice, Player owner)
    // {
    //     this.name = name;
    //     this.price = price;
    //     this.mortgagePrice = mortgagePrice;
    //     this.unmortgagePrice = unmortgagePrice;
    //     this.owner = owner;
    //     isMortgaged = false;
    //     isOwned = false;
    // }

    public override int CalculateRent() 
    { 
        // return (int)(railroadRent * Math.Pow(2, owner.railroadList.Count - 1)); 
        return railroadRent;
    }
}