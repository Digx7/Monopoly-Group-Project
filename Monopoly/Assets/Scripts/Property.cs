using System;
using System.Collections.Generic;

public class Property : Tile
{
    public PropertyColor propertyColorSet;
    public int numHouses = 0;
    // public int buildingPrice;
    // public int[] rentPrices;
    public PropertyRentPrices propertyRentPrices;
    
    // NOTE: Need to change to a reference not a variable

    // public Property(string name, string propertyColorSet, int price,
    //                                int mortgagePrice, int unmortgagePrice, int numHouses,
    //                                int buildingPrice, int[] rentPrices, bool isMortgaged,
    //                                bool isOwned, Player owner)
    // {
    //     this.name = name;
    //     this.propertyColorSet = propertyColorSet;
    //     this.price = price;
    //     this.mortgagePrice = mortgagePrice;
    //     this.unmortgagePrice = unmortgagePrice;
    //     this.numHouses = numHouses;
    //     this.buildingPrice = buildingPrice;
    //     this.rentPrices = rentPrices;
    //     this.isMortgaged = isMortgaged;
    //     this.isOwned = isOwned;
    //     this.owner = owner;
    // }

    public void BuyHouse()
    {
        // if (isOwned && !isMortgaged && owner.IsMonopoly(this) && numHouses < 5)
        // {
        //     numHouses += 1;
        //     owner.money += -1 * buildingPrice;
        // }

        numHouses++;
        // Debug.Log("" + name + "'s BuyHouse() increased numHouses to " + numHouses);
    }

    public void SellHouse()
    {
        numHouses--;
        // Debug.Log("" + name + "'s SellHouse() decreased numHouses to " + numHouses);
    }

    public override int CalculateRent()
    {
        // If there are no houses, check if Player owns the color set
        // If so, double the base rent. If not, return base rent

        if(numHouses == 0)
        {
            //if is monopoly return rentWithColorSet
            return propertyRentPrices.rent;
        }
        else
        {
            switch (numHouses)
            {
                case 1:
                    return propertyRentPrices.rentWith_1_Computer;
                    break;
                case 2:
                    return propertyRentPrices.rentWith_2_Computers;
                    break;
                case 3:
                    return propertyRentPrices.rentWith_3_Computers;
                    break;
                case 4:
                    return propertyRentPrices.rentWith_4_Computers;
                    break;
                case 5:
                    return propertyRentPrices.rentWithServer;
                    break;
                default:
                    return 0;
            }
        }

        return 10;
    }
}