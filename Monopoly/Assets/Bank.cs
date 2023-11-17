using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bank
{
    public int goSalary;
    public int purchasePrice;
    public bool hasProperty = false;
    public bool hasHouse1 = false;
    public bool hasHouse2 = false;
    public bool hasHouse3 = false;
    public bool hasHouse4 = false;
    public bool hasHotel = false;
    public Player player;
    
    public int PassingGo(int goSalary)
    {
        goSalary = 200;
        if(/*Player passes go*/)
        {
            return player.ModifyMoney(-goSalary);
        }
    }

    public int BuyingProperties(int propertyPrice)
    {
        if(hasProperty == false)
        {
            purchasePrice == Property.basePrice;  // Replace with correct syntax to get the price of each property
            hasProperty = true;
        }
        if(hasProperty == true)
        {
            playerBank = playerBank - purchasePrice;
            hasHouse1 = true;
        }
        if (hasHouse1 == true) 
        {
            playerBank = playerBank - purchasePrice;
            hasHouse2 = true;
        }
        if (hasHouse2 == true) 
        {
            playerBank = playerBank - purchasePrice;
            hasHouse3 = true;
        }
        if (hasHouse3 == true)
        {
            playerBank = playerBank - purchasePrice;
            hasHouse4 = true;
        }
        if (hasHouse4 == true) 
        {
            playerBank = playerBank - purchasePrice;
            hasHotel = true;
        }
    }
}
