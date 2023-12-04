using System;
using System.Collections.Generic;

public class Bank
{
    public Bank() {}

    public void Buy(Player player, Tile tile)
    {
        // Type type = tile.GetType();
        // if (type.Name == "Property")
        // {
        //     Property property = (Property)tile;
            
        //     player.Pay(property.price);
        //     property.owner = player;
        //     player.propertyDict[property.propertyColorSet].Add(property);
        //     property.isOwned = true;
            
        // }
        // else if (type.Name == "Railroad")
        // {
        //     Railroad railroad = (Railroad)tile;
            
        //     player.Pay(railroad.price);
        //     player.railroadList.Add(railroad);
        //     railroad.owner = player;
        //     railroad.isOwned = true;
        // }
        // else if (type.Name == "Utility")
        // {
        //     Utility utility = (Utility)tile;

        //     player.Pay(utility.price);
        //     player.utilityList.Add(utility);
        //     utility.owner = player;
        //     utility.isOwned = true;
        // }
    }


    // public void MortgageProperty(Player player, Tile tile)
    // {
    //     Type type = tile.GetType();
    //     if (type.Name == "Property")
    //     {
    //         Property property = (Property)tile;
    //         player.money += property.mortgagePrice;
    //         property.isMortgaged = true;
    //     }
    //     else if (type.Name == "Railroad")
    //     {
    //         Railroad railroad = (Railroad)tile;
    //         player.money += railroad.mortgagePrice;
    //         railroad.isMortgaged = true;
    //     }
    //     else if (type.Name == "Utility")
    //     {
    //         Utility utility = (Utility)tile;
    //         player.money += utility.mortgagePrice;
    //         utility.isMortgaged = true;
    //     }
    // }

    // public void UnmortgageProperty(Player player, Tile tile)
    // {
    //     Type type = tile.GetType();
    //     if (type.Name == "Property")
    //     {
    //         Property property = (Property)tile;
    //         player.money -= property.unmortgagePrice;
    //         property.isMortgaged = false;
    //     }
    //     else if (type.Name == "Railroad")
    //     {
    //         Railroad railroad = (Railroad)tile;
    //         player.money -= railroad.unmortgagePrice;
    //         railroad.isMortgaged = false;
    //     }
    //     else if (type.Name == "Utility")
    //     {
    //         Utility utility = (Utility)tile;
    //         player.money -= utility.unmortgagePrice;
    //         utility.isMortgaged = false;
    //     }
    // }


    // public void PayRent(Player player, Tile tile)
    // {
    //     Type type = tile.GetType();
    //     if (type.Name == "Property")
    //     {
    //         Property property = (Property)tile;
    //         int amount = property.CalculateRent();
    //         player.Pay(amount);
            
    //         if (player.money < 0)
    //             property.owner.money += amount + player.money;
    //         else property.owner.money += amount;
    //     }
    //     else if (type.Name == "Railroad")
    //     {
    //         Railroad railroad = (Railroad)tile;
    //         int amount = railroad.CalculateRent();
    //         player.Pay(amount);
    //         if (player.money < 0)
    //             railroad.owner.money += amount + player.money;
    //         else railroad.owner.money += amount;
    //     }
    //     else if (type.Name == "Utility")
    //     {
    //         Utility utility = (Utility)tile;
    //         int amount = utility.CalculateRent();
    //         player.Pay(amount);
    //         if (player.money < 0)
    //             utility.owner.money += amount + player.money;
    //         else utility.owner.money += amount;
    //     }
    // }
}