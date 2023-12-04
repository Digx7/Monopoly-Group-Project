using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropertyColorSet
{
    public PropertyColor color;
    public List<Property> owned;
    public int computerCost;

    public int totalHouses = 0;
    private int currentHouseIndex = 0;

    public PropertyColorSet()
    {
        color = PropertyColor.Purple;
        owned = new List<Property>();
    }
    public PropertyColorSet(PropertyColor _color)
    {
        color = _color;
        owned = new List<Property>();
    }

    public bool IsMonopoly()
    {
        int max = 3;
        if(color == PropertyColor.Purple || color == PropertyColor.DarkBlue)
        {
            max = 2;
        }

        if(owned.Count == max) return true;
        else return false;
    }

    public void BuyComputer()
    {
        Debug.Log("PropertyColerSet starting BuyComputer\ncurrentHouseIndex: " + currentHouseIndex);

        if(!IsMonopoly()) 
        {
            Debug.Log("PropertyColerSet is NOT a monopoly and is terminating BuyComputer()");
            return;
        }

        totalHouses++;
        if(totalHouses > MaxPossibleHouses())
        {
            Debug.Log("PropertyColerSet BuyComputer() totalHouses exceeded MasPossibleHouses():" + totalHouses + "\nreseting and terminating");
            totalHouses = MaxPossibleHouses();
            return;
        }

        owned[currentHouseIndex].BuyHouse();
        currentHouseIndex++;
        Debug.Log("PropertyColerSet bougth a house\ncurrentHouseIndex: " + currentHouseIndex);

        if(color == PropertyColor.Purple || color == PropertyColor.DarkBlue)
        {
            if(currentHouseIndex >= 2) 
            {
                Debug.Log("PropertyColerSet currentHouseIndex >= 2 : " + currentHouseIndex + "\n reseting to 0");
                currentHouseIndex = 0;
            }
            if(totalHouses == MaxPossibleHouses()) 
            {
                Debug.Log("PropertyColerSet totalHouses == MaxPossibleHouses() : " + totalHouses + "\n reseting currentHouseIndex to 1");
                currentHouseIndex = 2;
            }
        }
        else
        {
            if(currentHouseIndex >= 3) 
            {
                currentHouseIndex = 0;
            }
            if(totalHouses == MaxPossibleHouses()) 
            {
                currentHouseIndex = 3;
            }
        }
    }

    public void SellComputer()
    {
        Debug.Log("PropertyColerSet starting SellComputer\ncurrentHouseIndex: " + currentHouseIndex);
        if(!IsMonopoly()) 
        {
            Debug.Log("PropertyColerSet is NOT a monopoly and is terminating BuyComputer()");
            return;
        }
        
        totalHouses--;
        if(totalHouses < 0) 
        {
            Debug.Log("PropertyColerSet SellComputer() totalHouses < 0:" + totalHouses + "\nreseting and terminating");
            totalHouses = 0;
            return;
        }

        currentHouseIndex--;

        if(color == PropertyColor.Purple || color == PropertyColor.DarkBlue)
        {
            if(currentHouseIndex < 0) 
            {
                Debug.Log("PropertyColerSet currentHouseIndex < 0 : " + currentHouseIndex + "\n reseting to 1");
                currentHouseIndex = 1;
            }
            if(totalHouses == 0) 
            {
                Debug.Log("PropertyColerSet totalHouses == 0 : " + totalHouses + "\n reseting currentHouseIndex to 1");
                currentHouseIndex = 0;
            }
        }
        else
        {
            if(currentHouseIndex < 0) 
            {
                currentHouseIndex = 2;
            }
            if(totalHouses == 0) 
            {
                currentHouseIndex = 0;
            }
        }

        owned[currentHouseIndex].SellHouse();
        Debug.Log("PropertyColerSet sold a house\ncurrentHouseIndex: " + currentHouseIndex);

        // if(color == PropertyColor.Purple || color == PropertyColor.DarkBlue)
        // {
        //     if(currentHouseIndex < 0) 
        //     {
        //         Debug.Log("PropertyColerSet currentHouseIndex < 0 : " + currentHouseIndex + "\n reseting to 1");
        //         currentHouseIndex = 1;
        //     }
        //     if(totalHouses == 0) 
        //     {
        //         Debug.Log("PropertyColerSet totalHouses == 0 : " + totalHouses + "\n reseting currentHouseIndex to 1");
        //         currentHouseIndex = 0;
        //     }
        // }
        // else
        // {
        //     if(currentHouseIndex < 0) 
        //     {
        //         currentHouseIndex = 2;
        //     }
        //     if(totalHouses == 0) 
        //     {
        //         currentHouseIndex = 0;
        //     }
        // }
    }

    private int MaxPossibleHouses()
    {
        if(color == PropertyColor.Purple || color == PropertyColor.DarkBlue)
        {
            return 10;
        }
        return 15;
    }

    public bool MaxPossibleHousesReached()
    {
        if(totalHouses == MaxPossibleHouses()) return true;
        else return false;
    }

    public void Add(Property property)
    {
        if(owned.Contains(property)) return;

        owned.Add(property);

        totalHouses += property.numHouses;
        computerCost = property.propertyRentPrices.computerCost;
    }

    public void Remove(Property property)
    {
        if(!owned.Contains(property)) return;

        owned.Remove(property);

        totalHouses -= property.numHouses;
    }
}
