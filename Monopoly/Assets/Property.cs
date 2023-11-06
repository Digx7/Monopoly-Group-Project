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

        // TODO: Add logic here if needed
    }

    public int CalculateRent()
    {
        // If there are no houses, check if Player owns the color set
        // If so, double the base rent. If not, return base rent
        if (numHouses == 0)
        {
            if isCompleteColorSet() {
                return rentPrices[0] * 2;
            }
            else
            {
                return rentPrices[0]
            }
        }
        else
        {
            return rentPrices[numHouses];
        }
    }
    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    { 

    }
}