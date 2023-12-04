using System;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public int number;
    public string name;

    public int avatar;
    
    // public Dictionary<string, List<Property>> propertyDict;
    public List<PropertyColorSet> ownedPropertySets;
    public List<Railroad> railroadList;
    public List<Utility> utilityList;
    public int money = 0;
    public int out_of_jail_count = 0;
    public int jailRollCount = 0;
    public bool inJail = false;
    private int Location = 0;
    public int location
    {
        get { return Location; }
        set 
        { 
            if (value >= 0 && value < 40) Location = value;
            else Location = 0;
        }
    }
    // public Dictionary<string, bool> monopolies;
    // public bool meAgain = false;
    // public bool shouldRoll;

    public Player()
    {
        ownedPropertySets = new List<PropertyColorSet>();
        railroadList = new List<Railroad>();
        utilityList = new List<Utility>();
        
        
        PropertyColorSet purpleSet = new PropertyColorSet(PropertyColor.Purple);
        ownedPropertySets.Add(purpleSet);

        PropertyColorSet lightBlueSet = new PropertyColorSet(PropertyColor.LightBlue);
        ownedPropertySets.Add(lightBlueSet);

        PropertyColorSet pinkSet = new PropertyColorSet(PropertyColor.Pink);
        ownedPropertySets.Add(pinkSet);

        PropertyColorSet orangeSet = new PropertyColorSet(PropertyColor.Orange);
        ownedPropertySets.Add(orangeSet);

        PropertyColorSet redSet = new PropertyColorSet(PropertyColor.Red);
        ownedPropertySets.Add(redSet);

        PropertyColorSet yellowSet = new PropertyColorSet(PropertyColor.Yellow);
        ownedPropertySets.Add(yellowSet);

        PropertyColorSet greenSet = new PropertyColorSet(PropertyColor.Green);
        ownedPropertySets.Add(greenSet);

        PropertyColorSet darkBlueSet = new PropertyColorSet(PropertyColor.DarkBlue);
        ownedPropertySets.Add(darkBlueSet);
    }


    public void MoveLocation(int amount)
    {
        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                if (location == 39) location = 0;
                else location++;
            }
        }
        else if (amount < 0)
        {
            for (int i = 0; i > amount; i--)
            {
                if (location == 0) location = 39;
                else location--;
            }
        }
    }


    public void AddProperty(Property property) 
    { 
        // propertyDict[property.propertyColorSet].Add(property); 
    }


    public void RemoveProperty(string color, string name)
    {
        // int index = propertyDict[color].FindIndex(property => property.name == name);
        // if (index != -1) propertyDict[color].RemoveAt(index);
    }


    public bool IsMonopoly(Property property)
    {
        // if (property.propertyColorSet == "Purple" || property.propertyColorSet == "Dark Blue")
        //     if (propertyDict[property.propertyColorSet].Count >= 2)
        //         return true;
        // else
        //     if (propertyDict[property.propertyColorSet].Count >= 3)
        //         return true;
        return false;
    }


    public void UpdateMonopolies()
    {
        // List<string> colorsToUpdate = new List<string>();
        // foreach ((string color, bool b) in monopolies)
        // {
        //     if (color == "Purple" || color == "Dark Blue")
        //         if (propertyDict[color].Count == 2)
        //             colorsToUpdate.Add(color);
        //     else
        //         if (propertyDict[color].Count == 3)
        //             colorsToUpdate.Add(color);
        // }
        // foreach (string c in colorsToUpdate)
        // {
        //     monopolies[c] = true;
        // }
    }


    public void AddRailroad(Railroad railroad) { railroadList.Add(railroad); }


    public void RemoveRailroad(string name)
    {
        // int index = railroadList.FindIndex(railroad => railroad.name == name);
        // if (index != -1) railroadList.RemoveAt(index);
    }


    public void AddUtility(Utility utility) 
    { 
        // utilityList.Add(utility); 
    }


    public void RemoveUtility(string name)
    {
        // int index = utilityList.FindIndex(utility => utility.name == name);
        // if (index != -1) utilityList.RemoveAt(index);
    }


    public bool hasUnmortgaged()
    {
        // foreach ((string color, List<Property> properties) in propertyDict)
        //     foreach (Property property in properties)
        //         if (!property.isMortgaged) return true;
        
        // foreach (Railroad railroad in railroadList)
        //     if (!railroad.isMortgaged) return true;

        // foreach (Utility utility in utilityList)
        //     if (!utility.isMortgaged) return true;

        return false;
    }

    public bool hasMortgaged()
    {
        // foreach ((string color, List<Property> properties) in propertyDict)
        //     foreach (Property property in properties)
        //         if (property.isMortgaged) return true;
        
        // foreach (Railroad railroad in railroadList)
        //     if (railroad.isMortgaged) return true;

        // foreach (Utility utility in utilityList)
        //     if (utility.isMortgaged) return true;

        return false;
    }

    public void MortgageSequence(int amount)
    {
        // while (money < amount)
        // {
        //     if (hasUnmortgaged())
        //     {
        //         // creates and updates lists for unmortgaged stuff
        //         List<Property> unmortgagedProperties = new List<Property>();
        //         List<Railroad> unmortgagedRailroads = new List<Railroad>();
        //         List<Utility> unmortgagedUtilities = new List<Utility>();
                
        //         foreach ((string color, List<Property> properties) in propertyDict)
        //             foreach (Property property in properties)
        //                 if (!property.isMortgaged) unmortgagedProperties.Add(property);
                
        //         foreach (Railroad railroad in railroadList)
        //             if (!railroad.isMortgaged) unmortgagedRailroads.Add(railroad);

        //         foreach (Utility utility in utilityList)
        //             if (!utility.isMortgaged) unmortgagedUtilities.Add(utility);
                

        //         // displays player's unmortgaged assets
        //         Console.WriteLine(); 
        //         Console.WriteLine("__Unmortgaged Assets__");
                
        //         if (unmortgagedProperties.Count > 0)
        //         { 
        //             Console.WriteLine("Properties:");
        //             foreach (Property property in unmortgagedProperties)
        //                 Console.WriteLine($"    {property.propertyColorSet}: {property.name} -> ${property.mortgagePrice}");
        //         }

        //         if (unmortgagedRailroads.Count > 0)
        //         {
        //             Console.WriteLine("Railroads:");
        //             foreach (Railroad railroad in unmortgagedRailroads)
        //                 Console.WriteLine($"    {railroad.name} -> ${railroad.mortgagePrice}");
        //         }
                
        //         if (unmortgagedUtilities.Count > 0)
        //         {
        //             Console.WriteLine("Utilities:");
        //             foreach (Utility utility in unmortgagedUtilities)
        //                 Console.WriteLine($"    {utility.name} -> ${utility.mortgagePrice}");
        //         }

        //         Console.WriteLine();

        //         // handles player input
        //         while (true)
        //         {
        //             Console.Write("Pick an asset: ");
        //             string choice = Console.ReadLine();
        //             int index1 = unmortgagedProperties.FindIndex(property => property.name == choice);
        //             int index2 = unmortgagedRailroads.FindIndex(railroad => railroad.name == choice);
        //             int index3 = unmortgagedUtilities.FindIndex(utility => utility.name == choice);
        //             if (index1 != -1) 
        //             {
        //                 unmortgagedProperties[index1].isMortgaged = true;
        //                 money += unmortgagedProperties[index1].mortgagePrice;
        //                 break;
        //             }
        //             else if (index2 != -1)
        //             { 
        //                 unmortgagedRailroads[index2].isMortgaged = true;
        //                 money += unmortgagedRailroads[index2].mortgagePrice;
        //                 break;
        //             }
        //             else if (index3 != -1)
        //             {
        //                 unmortgagedUtilities[index3].isMortgaged = true;
        //                 money += unmortgagedUtilities[index3].mortgagePrice;
        //                 break;
        //             }
        //             else Console.WriteLine("Invalid input.");
        //         }
        //         Console.WriteLine($"Your new balance is: ${money}");
        //         Console.WriteLine();
        //     }
        //     else break;
        // }
    }

    public void Pay(int amount)
    {
        // MortgageSequence(amount);
        // money -= amount;
        // Console.WriteLine($"You paid ${amount}. Your new balance is ${money}.");
    }
}