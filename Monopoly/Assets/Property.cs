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
    public int[] rentPrices;
    public Player owner;

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