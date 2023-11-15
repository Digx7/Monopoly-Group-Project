using UnityEngine;
using UnityEngine.Experimental.Rendering;

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
    public Player[] currPlayers;

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


    public bool IsMonopoly()
    {

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
            player.Bank -= purchasePrice;
            // Replace Bank with whatever variable keeps track of player's bank
        } 
        else:
            return "This property has already been purchased."
    }

    public void BuyHouse()
    {
        if (isOwned && !isMortgaged && IsMonopoly() < 5)
        {
            numHouses += 1
            owner.Bank -= buildingPrice;
            // Replace Bank with whatever variable keeps track of player's bank
        }
    }

    public void PayRent(Player[] currPlayers) 
    {
        if (!isMortgaged)
        {
            for (int i = 0; i < currPlayers.Length; i++)
            {
                if currPlayers[i] != owner {
                    int rentOwed = CalculateRent()
                    currPlayers[i].Bank -= rentOwed;
                    owner.Bank += rentOwed;
                    // Replace Bank with whatever variable keeps track of player's bank
                }
            }
        }

    }

    public void MortgageProperty()
    {
        owner.Bank += mortgagePrice;
        // Replace Bank with whatever variable keeps track of player's bank
        isMortgaged = true;
    }

    public void UnmortgageProperty()
    {
        owner.Bank -= unmortgagePrice;
        // Replace Bank with whatever variable keeps track of player's bank
        isMortgaged = false;
    }

    public int CalculateRent()
    {
        // If there are no houses, check if Player owns the color set
        // If so, double the base rent. If not, return base rent
        if (numHouses == 0)
        {
            if IsMonopoly() {
                return rentPrices[1];
            }
            else
            {
                return rentPrices[0]
            }
        }
        else
        {
            return rentPrices[1 + numHouses];
        }
    }
}