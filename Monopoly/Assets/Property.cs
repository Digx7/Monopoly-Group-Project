using System;
using System.Collections.Generic;
using UnityEngine;

public class Property : Tile
{
    public string propertyName;
    public string propertyColorSet;
    public int purchasePrice;
    public int mortgagePrice;
    public int unmortgagePrice;
    public int numHouses;
    public int buildingPrice;
    public int[] rentPrices;
    public bool isMortgaged;
    public bool isOwned;
    public Player owner;

    public void InitializeProperty(string propertyName, string propertyColorSet, int purchasePrice,
                                   int mortgagePrice, int unmortgagePrice, int numHouses,
                                   int buildingPrice, int[] rentPrices, bool isMortgaged,
                                   bool isOwned, Player owner)
    {
        this.propertyName = propertyName;
        this.propertyColorSet = propertyColorSet;
        this.purchasePrice = purchasePrice;
        this.mortgagePrice = mortgagePrice;
        this.unmortgagePrice = unmortgagePrice;
        this.numHouses = numHouses;
        this.buildingPrice = buildingPrice;
        this.rentPrices = rentPrices;
        this.isMortgaged = isMortgaged;
        this.isOwned = isOwned;
        this.owner = owner;
    }

    public void SetOwner(Player player)
    {
        owner = player;
        isOwned = true;
    }

    public void BuyProperty(Player player)
    {
        if (!isOwned)
        {
            SetOwner(player);
            player.ModifyMoney(-1 * purchasePrice);
        }
    }

    public void BuyHouse()
    {
        if (isOwned && !isMortgaged && IsMonopoly() && numHouses < 5)
        {
            numHouses += 1;
            owner.ModifyMoney(-1 * buildingPrice);
        }
    }

    public void PayRent(Player player)
    {
        if (!isMortgaged)
        {
            if (player != owner)
            {
                int rentOwed = CalculateRent();
                player.ModifyMoney(-1 * rentOwed);
                owner.ModifyMoney(rentOwed);
            }
        }
    }

    public void MortgageProperty()
    {
        owner.ModifyMoney(mortgagePrice);
        isMortgaged = true;
    }

    public void UnmortgageProperty()
    {
        owner.ModifyMoney(-1 * unmortgagePrice);
        isMortgaged = false;
    }

    public int CalculateRent()
    {
        // If there are no houses, check if Player owns the color set
        // If so, double the base rent. If not, return base rent
        if (numHouses == 0)
        {
            if (IsMonopoly())
            {
                return rentPrices[1];
            }
            else
            {
                return rentPrices[0];
            }
        }
        else
        {
            return rentPrices[1 + numHouses];
        }
    }
}