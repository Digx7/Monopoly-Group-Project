using System;
using System.Collections.Generic;

public class Utility : Tile
{

    // public Utility(string name, int price, int mortgagePrice, int unmortgagePrice, Player owner)
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
        //  Dice UtilityDice = new Dice(); // Need to figure out refrence to dice role
        //  UtilityDice.Roll();

        //  if (owner.utilityList.Count == 2) //if player has both cards
        //  {
        //      return UtilityDice.total * 10; //roll dice times 10
        //  }
        //  else if (owner.utilityList.Count == 1) // checks to see if player has at least one card
        //  {
        //      return UtilityDice.total * 4; //roll dice times 4
        //  }
        return 10;
    }
}